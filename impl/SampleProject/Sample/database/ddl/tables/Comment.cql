USE "Sample";

CREATE TABLE "Comment" (
	"CommentID" timeuuid,
	"ParentCommentID" timeuuid,
	"Content" text,
	"PostID" timeuuid,
	"Author" text,
	PRIMARY KEY ("PostID", "CommentID")
);

CREATE INDEX ON "Comment" ("CommentID");
