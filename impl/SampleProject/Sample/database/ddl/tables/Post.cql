USE "TODO";

CREATE TABLE "Post" (
	"PostID" timeuuid,
	"Title" text,
	"Content" text,
	"CommentsNumber" int,
	"Author" text,
	PRIMARY KEY ("PostID")
);

CREATE INDEX ON "Post" ("Author");
