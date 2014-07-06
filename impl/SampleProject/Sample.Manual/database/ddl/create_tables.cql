USE "Sample_Manual";

CREATE TABLE IF NOT EXISTS "Post" (
	"PostID" int,
	"Title" text,
	"Content" text,
	"Author" text,
	"CommentsNumber" int,
	PRIMARY KEY ("PostID")
);

CREATE TABLE IF NOT EXISTS "User" (
	"UserName" text,
	"FirstName" text,
	"LastName" text,
	PRIMARY KEY ("UserName")
);
