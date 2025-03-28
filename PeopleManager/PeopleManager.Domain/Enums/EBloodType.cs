using System.Collections.Generic;

namespace PeopleManager.Domain.Enums
{
    public enum EBloodType
    {
        None = 0,
        A = 1,
        B = 2,
        AB = 3,
        O = 4
    }

    public static class EBloodTypeUtils
    {
        public static IList<EBloodType> GetAll() 
            => [EBloodType.None, EBloodType.A, EBloodType.B, EBloodType.AB, EBloodType.O];
    } 
}
