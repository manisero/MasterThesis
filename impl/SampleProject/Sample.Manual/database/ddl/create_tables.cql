USE "Sample_Manual";

CREATE TABLE IF NOT EXISTS "Posts" (
	"PostID" int,
	"Title" text,
	"Content" text,
	"Author" text,
	"CommentsNumber" int,
	PRIMARY KEY ("PostID")
);

CREATE TABLE IF NOT EXISTS "Users" (
	"UserName" text,
	"FirstName" text,
	"LastName" text,
	PRIMARY KEY ("UserName")
);
