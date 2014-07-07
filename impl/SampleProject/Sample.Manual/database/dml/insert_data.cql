USE "Sample_Manual";

INSERT INTO "Post" ("PostID", "Title", "Content", "Author", "CommentsNumber")
VALUES (now(), 'Hello World!', 'First post.', 'manisero', 3);

INSERT INTO "Post" ("PostID", "Title", "Content", "Author", "CommentsNumber")
VALUES (now(), 'My master''s thesis subject', 'Actually this is my master''s thesis subject.', 'manisero', 2);

INSERT INTO "User" ("UserName", "FirstName", "LastName")
VALUES ('manisero', 'Michal', 'Aniserowicz');

INSERT INTO "User" ("UserName", "FirstName", "LastName")
VALUES ('Your mom', 'Your', 'Mom');

INSERT INTO "User" ("UserName", "FirstName", "LastName")
VALUES ('Saudi arabia prince', 'Saudi', 'Prince');
