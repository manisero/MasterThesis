USE sample_manual;

CREATE TABLE IF NOT EXISTS "Posts" (
	"PostID" int,
	"Title" text,
	"Content" text,
	"Author" text,
	"CommentsNumer" int,
	PRIMARY KEY ("PostID")
);

CREATE TABLE IF NOT EXISTS "Users" (
	"UserName" text,
	"FirstName" text,
	"LastName" text,
	PRIMARY KEY ("UserName")
);
