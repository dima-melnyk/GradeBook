namespace GradeBook.BusinessLogic.Constants
{
    public static class GradeExceptionMessages
    {
        public const string IncorrectRoleException = "Only pupil can have grades";
        public const string IncorrectPupilException = "Pupil is not member of this class";
        public const string IllegalAccessException = "User doesn\'t have access to this information";
    }
}
