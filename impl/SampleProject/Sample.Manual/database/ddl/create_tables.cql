USE "Sample_Manual";



CREATE TABLE "Post" (
	"PostID" int,
	"Title" text,
	"Content" text,
	"Author" text,
	"CommentsNumber" int,
	PRIMARY KEY ("PostID")
);

CREATE INDEX ON "Post"("Author");



CREATE TABLE "User" (
	"UserName" text,
	"FirstName" text,
	"LastName" text,
	PRIMARY KEY ("UserName")
);
