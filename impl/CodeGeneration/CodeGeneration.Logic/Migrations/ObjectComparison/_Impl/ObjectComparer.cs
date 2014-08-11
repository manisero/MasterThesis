using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CodeGeneration.Logic.Extensions;

namespace CodeGeneration.Logic.Migrations.ObjectComparison._Impl
{
    public class ObjectComparer : IObjectComparer
    {
        private readonly IKeyChangeDetector _keyChangeDetector;

        public ObjectComparer(IKeyChangeDetector keyChangeDetector)
        {
            _keyChangeDetector = keyChangeDetector;
        }

        public Delta Compare<T>(T old, T @new)
        {
            return Compare(old, @new, typeof(T));
        }

        private Delta Compare(object old, object @new, Type type)
        {
            var result = new Delta();
            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                var oldValue = property.GetValue(old);
                var newValue = property.GetValue(@new);

                if (property.PropertyType.IsPrimitive())
                {
                    if (oldValue == null && newValue != null || oldValue != null && !oldValue.Equals(newValue))
                    {
                        result.SimplePropertyDeltas[property.Name] = new SimplePropertyDelta
                            {
                                OldValue = oldValue,
                                NewValue = newValue
                            };
                    }
                }
                else if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
                {
                    var itemType = property.PropertyType.GenericTypeArguments[0];

                    if (property.PropertyType.IsPrimitive())
                    {
                        var delta = CompareSimpleCollections((IEnumerable)oldValue, (IEnumerable)newValue, itemType);

                        if (!delta.IsEmpty())
                        {
                            result.SimpleCollectionDeltas[property.Name] = delta;
                        }
                    }
                    else
                    {
                        var delta = CompareComplexCollections((IEnumerable)oldValue, (IEnumerable)newValue, itemType);

                        if (!delta.IsEmpty())
                        {
                            result.ComplexCollectionDeltas[property.Name] = delta;
                        }
                    }
                }
                else
                {
                    var delta = Compare(oldValue, newValue, property.PropertyType);

                    if (!delta.IsEmpty())
                    {
                        result.ComplexPropertyDeltas[property.Name] = delta;
                    }
                }
            }

            return result;
        }

        private SimpleCollectionDelta CompareSimpleCollections(IEnumerable oldCollection, IEnumerable newCollection, Type itemType)
        {
            var oldItems = (oldCollection ?? new object[0]).Cast<object>().ToDictionary(x => GetKey(x, itemType));
            var newItems = (newCollection ?? new object[0]).Cast<object>().ToDictionary(x => GetKey(x, itemType));
            var result = new SimpleCollectionDelta();

            foreach (var oldItem in oldItems)
            {
                if (!newItems.Any(x => x.Key == oldItem.Key))
                {
                    result.RemovedItems.Add(oldItem);
                }
            }

            foreach (var newItem in newItems)
            {
                if (!oldItems.Any(x => x.Key == newItem.Key))
                {
                    result.AddedItems.Add(newItem);
                }
            }

            return result;
        }

        private ComplexCollectionDelta CompareComplexCollections(IEnumerable oldCollection, IEnumerable newCollection, Type itemType)
        {
            var oldItems = (oldCollection ?? new object[0]).Cast<object>().ToDictionary(x => GetKey(x, itemType));
            var newItems = (newCollection ?? new object[0]).Cast<object>().ToDictionary(x => GetKey(x, itemType));
            var matchedKeys = oldItems.Keys.Intersect(newItems.Keys).ToDictionary(x => x, x => x);
            var result = new ComplexCollectionDelta();

            foreach (var oldItem in oldItems)
            {
                var correspondingNewItem = matchedKeys.ContainsKey(oldItem.Key)
                                               ? newItems[oldItem.Key]
                                               : newItems.SingleOrDefault(x => CheckKeysMatch(oldItem.Key, oldItem.Value, x.Key, x.Value, matchedKeys)).Value;

                if (correspondingNewItem != null)
                {
                    var delta = Compare(oldItem.Value, correspondingNewItem, itemType);

                    if (!delta.IsEmpty())
                    {
                        result.ModifiedItems[oldItem.Key] = delta;
                    }
                }
                else
                {
                    result.RemovedItems.Add(oldItem.Value);
                }
            }

            foreach (var newItem in newItems)
            {
                if (!matchedKeys.ContainsValue(newItem.Key))
                {
                    result.AddedItems.Add(newItem.Value);
                }
            }

            return result;
        }

        private string GetKey(object item, Type type)
        {
            var properties = type.GetProperties();
            var keyPropertyNames = new[] { "Key", "Name", "ID" };

            foreach (var keyPropertyName in keyPropertyNames)
            {
                var keyProperty = properties.SingleOrDefault(x => x.Name == keyPropertyName);

                if (keyProperty != null && keyProperty.PropertyType == typeof(string))
                {
                    return (string)keyProperty.GetValue(item);
                }
            }
            
            throw new InvalidOperationException(string.Format("Could not determine the of type '{0}'.", type.FullName));
        }

        private bool CheckKeysMatch(string oldKey, object oldItem, string newKey, object newItem, Dictionary<string, string> matchedKeys)
        {
            if (matchedKeys.ContainsKey(oldKey))
            {
                return false;
            }

            if (matchedKeys.ContainsValue(newKey))
            {
                return false;
            }

            if (_keyChangeDetector.IsTheSameItem(oldItem, oldKey, newItem, newKey))
            {
                matchedKeys[oldKey] = newKey;
                return true;
            }

            return false;
        }
    }
}
