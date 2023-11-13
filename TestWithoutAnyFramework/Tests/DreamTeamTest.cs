using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWithoutAnyFramework.Tests
{
    public static class DreamTeamTest
    {
        //Naming Conventions -> ClassName_MethodName_ExpectedResult
        public static void DreamTeam_ReturnTsubasa_ReturnString()
        {
            try
            {
                //Arrange
                int num = 0;
                DreamTeam team = new DreamTeam();

                //Act
                string result = team.ReturnTsubasa(num);

                //Assert
                if (result == "Tsubasa Ozora")
                {
                    Console.WriteLine("PASSED: DreamTeam_ReturnTsubasa_ReturnString");
                }
                else
                {
                    Console.WriteLine("FAILED: DreamTeam_ReturnTsubasa_ReturnString");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
