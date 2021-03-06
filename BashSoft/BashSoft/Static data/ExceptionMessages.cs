﻿namespace BashSoft
{
    public static class ExceptionMessages
    {
        public const string ExampleExceptionMessage = "Example message!";
        public const string DataAlreadyInitializedException = "Data is already initialized!";

        public const string DataNotInitializedExceptionMessage =
            "The data structure must be initialized first to make any operations with it.";

        public const string InexistingCourseInDataBase = "The course you are trying to get does not exist in the data base.";
        public const string InexistingStudentInDataBase = "The user name for the student you are trying to get does not exist.";
       // public const string InvalidPath = "The folder/file you are trying to access at the current address, does not exist.";
        public const string UnauthorizedAccessExceptionMessage = "The folder/file you are trying to get acess needs a higher level of rights than you currently have.";
        public const string ComparisonOfFilesWithDifferentSizes = "Files not of equal size, certain mismatch.";
       // public const string ForbiddenSymbolsContainedInName = "The given name contains symbols that are not allowed to be used in names of files and folders.";
        public const string UnableToGoHigherInPartitionHierarchy = "Unable to go further in folder hierarchy.";
        public const string UnableToParseNumber = "The sequence you have written is not valid number";
        public const string InvalidStudentFilter = "The given filter is not one of the following: excellent/average/poor";
        public const string InvalidComparisonQuery = "The comparison query you want, does not exist in the context of the current program!";
        public const string InvalidTakeCommand = "The take command expected does not match the format wanted!";
        public const string InvalidTakeQuantity = "The take quantity expected does not match the format wanted!";
     //   public const string StudentAlreadyEnrolledInGivenCourse = "The {0} already exists in {1}.";
        public const string NotEnrolledInCourse = "Student must be enrolled in a course before you set his mark.";
        public const string InvalidNumberOfScores = "The number of scores for the given course is greater than the possible.";
        public const string InvalidScore = "The number for the score you've entered is not in the range of 0 - 100";
       // public const string NullOrEmptyValue = "The value of the variable CANNOT be null or empty!";
    }
}
