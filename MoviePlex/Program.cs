using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Authors :
 * Damanpreet Grewal - 8752500
 * Yashkumar Patel - 8739620
 * Binali Patel - 8739266
*/

namespace MoviePlex
{   
    //Declare a Class Movie to represent each Movie that will be showcased in our Theatre
    public class Movie
    {
        public int SerialNo { get; set; }
        public string Name { get; set; }
        public string AgeorRating { get; set; }
    }


    class Program
    {   
        //Declare a List that will store Objects of Type Movie Class
        public static List<Movie> MoviesList = new List<Movie> { };

        static void Main(string[] args)
        {
            Console.Title = "MoviePlex Movie Theatre Application";

            MoviePlexMainScreen();  //Call the MoviePlex Theate Main Screen Method
        }

        //MoviePlext Movie Theatre Console Header
        public static void ConsoleHeader()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t************************************");
            Console.Write("\t\t\t\t***");
            Console.ForegroundColor = ConsoleColor.DarkCyan; 
            Console.Write(" Welcome to MoviePlex Theatre");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" ***\n");
            Console.WriteLine("\t\t\t\t************************************");
        }

        //MoviePlex Theate Main Screen Method
        public static void MoviePlexMainScreen()
        {

            ConsoleHeader();
            int selection;

            Console.WriteLine("\nPlease Select From The Following Options:");
            Console.WriteLine("1: Administrator");
            Console.WriteLine("2: Guests");
            Console.WriteLine();

            bool continueFlag = false;

            do
            {
                Console.Write("Selection: ");
                if (int.TryParse(Console.ReadLine().Trim(), out selection))
                {
                    if (selection == 1 || selection == 2)
                    {
                        continueFlag = true;
                        MoviePlexMainSubScreen(selection);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please Enter either 1 or 2 as Option.");
                        Console.ForegroundColor = ConsoleColor.White;
                        continueFlag = false;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please Enter a Valid Option/Number.");
                    Console.ForegroundColor = ConsoleColor.White;
                    continueFlag = false;
                }
            } while (continueFlag == false);
        }

        //Redirect to the Admin/Guest Login Page based on the Input Selection
        public static void MoviePlexMainSubScreen(int selection)
        {
            switch (selection)
            {
                case 1:
                    ConsoleHeader();
                    AdminLogin();
                    break;
                case 2:
                    ConsoleHeader();
                    GuestLogin();
                    break;
                default:
                    Console.WriteLine("Invalid selection!");
                    break;
            }
        }

        //Admin Login UI Page
        public static void AdminLogin()
        {
            bool adminPWContinueFlag = false;
            int adminPWRetries = 0;
            do
            {
                string password;
                Console.Write("\nPlease Enter the Admin Password : ");
                password = Console.ReadLine().Trim();
                if (password == "Admin@123")
                {
                    Console.WriteLine("Authenticated Successfully!!");
                    adminPWContinueFlag = true;
                    AdminScreen();
                }
                else if (password == "B" || password == "b")
                {
                    MoviePlexMainScreen();
                }
                else
                {
                    Console.WriteLine("You entered an Invalid Password.");
                    adminPWRetries++;
                    Console.WriteLine("You have {0} more attempts to enter the correct password or Press B to go back to the previous Screen.", (5 - adminPWRetries));
                }

                if (adminPWRetries == 5)
                {
                    MoviePlexMainScreen();
                }
            } while (adminPWContinueFlag == false);

        }

        //Admin UI Sub-Screen
        public static void AdminScreen()
        {
            ConsoleHeader();
            MoviesList.Clear();
            Console.WriteLine("\n\nWelcome MoviePlex Administrator");

            int movieCount = 0;

        SetMoviesList:
            Console.Write("\nHow many movies are playing today?: ");
            if (int.TryParse(Console.ReadLine().Trim(), out movieCount))
            {
                if (movieCount < 1 || movieCount > 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please Enter the no. of Movies playing between 1 and 10!");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto SetMoviesList;
                    ;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please Enter a Valid Movie Count!");
                Console.ForegroundColor = ConsoleColor.White;
                goto SetMoviesList;

            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("");

            Console.WriteLine("-------------   Movie Ratings  ----------------");
            Console.WriteLine("G – General Audience, any age is good");
            Console.WriteLine("PG – We will take PG as 10 years or older");
            Console.WriteLine("PG-13 – We will take PG-13 as 13 years or older");
            Console.WriteLine("R – We will take R as 15 years or older. Don’t worry about accompany by parent case");
            Console.WriteLine("NC-17 – We will take NC-17 as 17 years or older");

            Console.ForegroundColor = ConsoleColor.White;


            string[] moviesSequence = { "First", "Second", "Third", "Fourth", "Fifth", "Sixth", "Seventh", "Eighth", "Ninth", "Tenth" };

            string movieName;
            string ageOrRating;

            bool CheckAgeOrRating(string age_or_rating)
            {
                int age;

                if (int.TryParse(age_or_rating, out age))
                {
                    if (age > 0 && age <= 120)
                    {
                        return true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please Enter an Age between 1 and 120.\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        return false;
                    }
                }
                else if (age_or_rating.ToUpper() == "G" || age_or_rating.ToUpper() == "PG" || age_or_rating.ToUpper() == "PG-13" || age_or_rating.ToUpper() == "R" || age_or_rating.ToUpper() == "NC-17")
                {
                    return true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please Enter a Valid Movie Rating!\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    return false;
                }
            }

            for (int i = 0; i < movieCount; i++)
            {
            AddMovie: Console.Write("\nPlease Enter The {0} Movie's Name: ", moviesSequence[i]);
                movieName = Console.ReadLine().Trim();
                if (movieName is null || movieName == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Movie name cannot be Blank!");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto AddMovie;
                }

                Console.Write("Please Enter The Age Limit or Rating For The {0} Movie: ", moviesSequence[i]);
                ageOrRating = Console.ReadLine().Trim();

                while (CheckAgeOrRating(ageOrRating) == false)
                {
                    Console.Write("Please Enter The Age Limit or Rating For The {0} Movie: ", moviesSequence[i]);
                    ageOrRating = Console.ReadLine().Trim();
                }

               MoviesList.Add(new Movie() { SerialNo = i+1 , Name = movieName, AgeorRating = ageOrRating.ToUpper() });
            }
                
            Console.WriteLine("\n");
                       
            foreach (Movie theMovie in MoviesList)
            {
                Console.WriteLine("\t"+theMovie.SerialNo + ". " + theMovie.Name + "  {" + theMovie.AgeorRating + "} ");

            }
                                   
           
            string satisfiedInput;
            bool continueFlag_satisfy = false;

            do
            {
                Console.WriteLine("\nYour Movies Playing Today Are Listed Above. Are you satisfied? (Y/N)?");
                Console.Write("Selection: ");
                satisfiedInput = Console.ReadLine().Trim();

                if (satisfiedInput == "Y" || satisfiedInput == "y")
                {
                    continueFlag_satisfy = true;
                    MoviePlexMainScreen();
                }
                else if (satisfiedInput == "N" || satisfiedInput == "n")
                {
                    continueFlag_satisfy = true;
                    AdminScreen();
                }
                else
                {
                    continueFlag_satisfy = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please Enter Y/y or N/n as an option.");
                    Console.ForegroundColor = ConsoleColor.White;
                }

            } while (continueFlag_satisfy == false);

        }

        //Guest Login UI Page
        public static void GuestLogin()
        {
            ConsoleHeader();
            if (MoviesList.Count() == 0)
            {
                string backToMenu_Input = "";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There are no movies playing today!\n");
                Console.ForegroundColor = ConsoleColor.White;

            BackToMenu_Input: Console.WriteLine("Press B to go to Main Menu : ");
                Console.Write("Selection: ");
                backToMenu_Input = Console.ReadLine().Trim();
                if (backToMenu_Input == "B" || backToMenu_Input == "b")
                {
                    MoviePlexMainScreen();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPlease Enter a Valid Selection.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto BackToMenu_Input;
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nThere are {0} movies playing today. Please choose from the following movies:", MoviesList.Count());
                Console.ForegroundColor = ConsoleColor.White;

            MovieSelectStartOver:
                Console.WriteLine();
                foreach (Movie theMovie in MoviesList)
                {
                    Console.WriteLine("\t" + theMovie.SerialNo + ". " + theMovie.Name + "  {" + theMovie.AgeorRating + "} ");

                }

                bool isMovieSelectedValid = false;
                int movieSelected = 0;
                bool isGuestAgeValid = false;
                int guestAge = 0;
             do
                {
                    Console.Write("\nWhich Movie Would You Like to Watch: ");
                    if (int.TryParse(Console.ReadLine().Trim(), out movieSelected))
                    {
                        if (movieSelected > MoviesList.Count() || movieSelected <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please select a movie between 1 and {0}.", MoviesList.Count());
                            Console.ForegroundColor = ConsoleColor.White;
                            isMovieSelectedValid = false;
                        }                        
                        else
                        {
                            isMovieSelectedValid = true;
                        }
                    }
                    else
                    {    if (movieSelected.ToString() == "")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("The Movie no. cannot be entered as Blank!");
                            Console.ForegroundColor = ConsoleColor.White;
                            isMovieSelectedValid = false;
                        } 
                        else { 
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please Enter a Valid Number For The Movie You Want To Watch!");
                        Console.ForegroundColor = ConsoleColor.White;
                        isMovieSelectedValid = false;
                        }
                    }
                } while (isMovieSelectedValid == false);

                //Dont ask for the Guest Age input if the Movie selected has Rating = 'G'
                if (MoviesList[movieSelected - 1].AgeorRating == "G")
                {
                    goto SkipAgeInput;
                }

                    do
                    {
                        Console.Write("\nPlease Enter Your Age For Verification: ");
                        if (int.TryParse(Console.ReadLine().Trim(), out guestAge))
                        {
                            if (guestAge <= 0 || guestAge > 120)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Please enter the age between 1 and 120!");
                                Console.ForegroundColor = ConsoleColor.White;
                                isGuestAgeValid = false;
                            }
                            else
                            {
                                isGuestAgeValid = true;
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please enter a Valid Age!");
                            Console.ForegroundColor = ConsoleColor.White;
                            isGuestAgeValid = false;
                        }
                    } while (isGuestAgeValid == false);


            SkipAgeInput: 
                if (MoviesList[movieSelected - 1].AgeorRating == "G" || MoviesList[movieSelected - 1].AgeorRating == "PG" || MoviesList[movieSelected - 1].AgeorRating == "PG-13" 
                    || MoviesList[movieSelected - 1].AgeorRating == "R" || MoviesList[movieSelected - 1].AgeorRating == "NC-17")
                {   
                    if(MoviesList[movieSelected - 1].AgeorRating == "G")
                    {
                    Console.WriteLine("\nEnjoy the Movie : {0}! ", MoviesList[movieSelected - 1].Name);
                    }
                    else if (MoviesList[movieSelected - 1].AgeorRating == "PG")
                    {   
                        if(guestAge>=10)
                        {
                            Console.WriteLine("\nEnjoy the Movie : {0}! ", MoviesList[movieSelected - 1].Name);
                        } else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You are under the age limit. Age should be greater than or equal to 10 To Watch The Movie : " + MoviesList[movieSelected - 1].Name + " {PG}.");
                            Console.WriteLine("Please Choose Another Movie from the List : ");
                            Console.ForegroundColor = ConsoleColor.White;
                            goto MovieSelectStartOver;
                        }
                    }
                    else if (MoviesList[movieSelected - 1].AgeorRating == "PG-13")
                    {
                        if (guestAge >= 13)
                        {
                            Console.WriteLine("\nEnjoy the Movie : {0}! ", MoviesList[movieSelected - 1].Name);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You are under the age limit.Age should be greater than or equal to 13 To Watch The Movie: " + MoviesList[movieSelected - 1].Name + " {PG-13}.");
                            Console.WriteLine("Please Choose Another Movie from the List!");
                            Console.ForegroundColor = ConsoleColor.White;
                            goto MovieSelectStartOver;
                        }
                    }
                    else if (MoviesList[movieSelected - 1].AgeorRating == "R")
                    {
                        if (guestAge >= 15)
                        {
                            Console.WriteLine("\nEnjoy the Movie : {0}! ", MoviesList[movieSelected - 1].Name);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You are under the age limit.Age should be greater than or equal to 15 To Watch The Movie: " + MoviesList[movieSelected - 1].Name + " {R}.");
                            Console.WriteLine("Please Choose Another Movie from the List!");
                            Console.ForegroundColor = ConsoleColor.White;
                            goto MovieSelectStartOver;
                        }
                    }
                    else 
                    {
                        if (guestAge >= 17)
                        {
                            Console.WriteLine("\nEnjoy the Movie : {0}! ", MoviesList[movieSelected - 1].Name);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You are under the age limit.Age should be greater than or equal to 17 To Watch The Movie: " + MoviesList[movieSelected - 1].Name + " {NC-17}.");
                            Console.WriteLine("Please Choose Another Movie from the List!");
                            Console.ForegroundColor = ConsoleColor.White;
                            goto MovieSelectStartOver;
                        }
                    }

               } else if (Int32.Parse(MoviesList[movieSelected - 1].AgeorRating).GetType() == typeof(Int32))
                    {
                        if(guestAge >= Int32.Parse(MoviesList[movieSelected - 1].AgeorRating))
                        {
                        Console.WriteLine("\nEnjoy the Movie : {0}! ", MoviesList[movieSelected - 1].Name);
                        }
                        else
                        {
                             Console.ForegroundColor = ConsoleColor.Red;
                             Console.WriteLine("You are under the age limit.Age should be greater than or equal to {0} To Watch The Movie : {1}", MoviesList[movieSelected - 1].AgeorRating , MoviesList[movieSelected - 1].Name);
                             Console.WriteLine("Please Choose Another Movie from the List: ");
                             Console.ForegroundColor = ConsoleColor.White;
                             goto MovieSelectStartOver;
                        }
                }
            }

            string backToGuestOrStartPage_Input = "";
            bool backToGuestOrStartPage_flag = false;
            Console.WriteLine("\nPress M to go back to the Guest Main Menu.");
            Console.WriteLine("Press S to go back to the Start Page.\n");

            do
            {
                Console.Write("Selection: ");
                backToGuestOrStartPage_Input = Console.ReadLine().Trim();

                if(backToGuestOrStartPage_Input == "M" || backToGuestOrStartPage_Input == "m")
                {
                    GuestLogin();
                }
                else if (backToGuestOrStartPage_Input == "S" || backToGuestOrStartPage_Input == "s")
                {
                    MoviePlexMainScreen();
                }
                else
                {
                    backToGuestOrStartPage_flag = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please Enter a Valid Input!");
                    Console.ForegroundColor = ConsoleColor.White;
                }                   

            } while (backToGuestOrStartPage_flag == false);

        }
    }
}
