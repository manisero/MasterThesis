USE "Sample_Manual";

CREATE TABLE "User" (
	"UserName" text,
	"FirstName" text,
	"LastName" text,
	PRIMARY KEY ("UserName")
);



CREATE TABLE "Post" (
	"PostID" timeuuid,
	"Title" text,
	"Content" text,
	"Author" text,
	"CommentsNumber" int,
	PRIMARY KEY ("PostID")
);

CREATE INDEX ON "Post"("Author");



CREATE TABLE "Comment" (
	"CommentID" timeuuid,
	"PostID" timeuuid,
	"Content" text,
	"Author" text,
	"ParentCommentID" timeuuid,
	PRIMARY KEY ("CommentID")
);
