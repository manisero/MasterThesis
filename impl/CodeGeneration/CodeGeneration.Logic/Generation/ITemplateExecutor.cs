﻿namespace CodeGeneration.Logic.Generation
{
    public interface ITemplateExecutor
    {
        string Execute<TMetadata>(object template, TMetadata metadata, IGenerationContext context);
    }
}
