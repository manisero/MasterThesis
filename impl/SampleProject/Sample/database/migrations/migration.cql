USE "Sample";

DROP INDEX "Comment_LikesNumber_idx";
ALTER TABLE "Comment" DROP "LikesNumber";

CREATE INDEX "Comment"."CommentID";


ALTER TABLE "Post" ADD "CommentsNumber" int;


ALTER TABLE "User" ADD "LastName" text;

DROP INDEX "User_Name_idx";
ALTER TABLE "User" RENAME "Name" TO "FirstName";
