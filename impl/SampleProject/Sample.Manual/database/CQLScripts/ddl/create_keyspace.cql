CREATE KEYSPACE sample_manual
WITH REPLICATION = { 'class' : 'SimpleStrategy', 'replication_factor' : 2 };
