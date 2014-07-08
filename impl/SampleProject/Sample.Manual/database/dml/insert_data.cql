USE "Sample_Manual";

INSERT INTO "User" ("UserName", "FirstName", "LastName")
VALUES ('manisero', 'Michal', 'Aniserowicz');

INSERT INTO "User" ("UserName", "FirstName", "LastName")
VALUES ('Your mom', 'Your', 'Mom');

INSERT INTO "User" ("UserName", "FirstName", "LastName")
VALUES ('Saudi Arabia prince', 'Saudi', 'Prince');



INSERT INTO "Post" ("PostID", "Title", "Content", "Author", "CommentsNumber")
VALUES (c40681a0-0618-11e4-bacb-01a1829c5281, 'Hello World!', 'First post.', 'manisero', 5);

INSERT INTO "Post" ("PostID", "Title", "Content", "Author", "CommentsNumber")
VALUES (c407e130-0618-11e4-bacb-01a1829c5281, 'My master''s thesis subject', 'Actually this is my master''s thesis subject.', 'manisero', 0);



INSERT INTO "Comment" ("PostID", "CommentID", "Content", "Author")
VALUES (c407e130-0618-11e4-bacb-01a1829c5281, f0954bf0-061a-11e4-bacb-01a1829c5281, 'Good luck with your thesis!', 'Your mom');

INSERT INTO "Comment" ("PostID", "CommentID", "Content", "Author", "ParentCommentID")
VALUES (c407e130-0618-11e4-bacb-01a1829c5281, f0943a80-061a-11e4-bacb-01a1829c5281, 'Thanks, mom', 'manisero', f0954bf0-061a-11e4-bacb-01a1829c5281);

INSERT INTO "Comment" ("PostID", "CommentID", "Content", "Author", "ParentCommentID")
VALUES (c407e130-0618-11e4-bacb-01a1829c5281, f095c120-061a-11e4-bacb-01a1829c5281, 'Yrw', 'Your mom', f0943a80-061a-11e4-bacb-01a1829c5281);

INSERT INTO "Comment" ("PostID", "CommentID", "Content", "Author", "ParentCommentID")
VALUES (c407e130-0618-11e4-bacb-01a1829c5281, f094d6c0-061a-11e4-bacb-01a1829c5281, 'Ah, and eat your dinner', 'Your mom', f0954bf0-061a-11e4-bacb-01a1829c5281);

INSERT INTO "Comment" ("PostID", "CommentID", "Content", "Author")
VALUES (c407e130-0618-11e4-bacb-01a1829c5281, f093c550-061a-11e4-bacb-01a1829c5281, 'Spam, spam, spam', 'Saudi Arabia prince');
