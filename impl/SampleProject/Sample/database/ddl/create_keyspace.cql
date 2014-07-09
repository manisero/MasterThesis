CREATE KEYSPACE "Sample"
WITH REPLICATION = 
	{
		'class': 'SimpleStrategy',
		'replication_factor' : 1
	};
