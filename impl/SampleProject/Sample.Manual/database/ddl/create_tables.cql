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
	"PostID" timeuuid,
	"CommentID" timeuuid,
	"Content" text,
	"Author" text,
	"ParentCommentID" timeuuid,
	PRIMARY KEY ("PostID", "CommentID")
);

CREATE INDEX ON "Comment"("CommentID");
