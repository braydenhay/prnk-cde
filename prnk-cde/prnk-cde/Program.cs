//Default Assemblies.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//For multithreading.
using System.Threading;

//For mouse & keyboard manipulation.
using System.Windows.Forms;

//For playing system sounds.
using System.Media;

namespace sysmgr
{
    /// <summary>
    /// A prank application that jumbles keyboard and mouse input.
    /// </summary>
    /// 
    /// Application Name: "sysmgr"
    /// Developer: Brayden Hay
    /// Code Originally By: Barnacules
    class Program
    {
        public static Random _random = new Random();

        /// <summary>
        /// Entry point for application.
        /// </summary>
        /// <param name="args">Useless Arguments</param>
        static void Main(string[] args)
        {
            Console.WriteLine("sysmgr program by Brayden Hay, based off of code by Jerry (aka. Barnacules).");
            Console.WriteLine();

            //Create threads for various generators.
            Thread mThread = new Thread(new ThreadStart(MouseThread));
            Thread kThread = new Thread(new ThreadStart(KeyboardThread));
            Thread sThread = new Thread(new ThreadStart(SoundThread));
            Thread pThread = new Thread(new ThreadStart(PopupThread));

            //Start the threads.
            mThread.Start();
            kThread.Start();
            sThread.Start();
            pThread.Start();

            //On a key press... (ONLY FOR RESTING. REMOVED IN FINAL PRODUCT)
            Console.Read();

            //Kill all threads and exit application.
            mThread.Abort();
            kThread.Abort();
            sThread.Abort();
            pThread.Abort();
        }

        /// <summary>
        /// Generates random mouse movement.
        /// </summary>
        static void MouseThread()
        {
            Console.WriteLine("MouseThread Running.");

            //Create various variables to control movement, with the "check" variables determining polarity, and the "mod" variables determining magnitude.
            int checkX = 0;
            int checkY = 0;
            int modX = 0;
            int modY = 0;

            while (true)
            {
                //A little RNG to determine polarity and magnitude of the random cursor movement.
                checkX = _random.Next(2);
                checkY = _random.Next(2);
                modX = _random.Next(10);
                modY = _random.Next(10);

                //If the "check" variables are 0, make the corresponding "mod" variables negative.
                if (checkX == 1)
                {

                }
                else if (checkX == 0)
                {
                    modX = modX * (-1);
                }
                else
                {
                    Console.WriteLine("THE RANDOM NUMBER GENERATOR IS BROKEN.");
                }

                if (checkY == 1)
                {

                }
                else if (checkY == 0)
                {
                    modY = modY * (-1);
                }
                else
                {
                    Console.WriteLine("THE RANDOM NUMBER GENERATOR IS BROKEN.");
                }

                //Move cursor based on modX, modY, and the current cursor positions.
                Cursor.Position = new System.Drawing.Point(Cursor.Position.X + modX, Cursor.Position.Y + modY);

                //Sleep from 0.5 to 1.0 seconds.
                Thread.Sleep(_random.Next(500) + 500);
            }
        }

        /// <summary>
        /// Generates random keypresses.
        /// </summary>
        static void KeyboardThread()
        {
            Console.WriteLine("KeyboardThread Running.");

            //Create ASCII variable to dictate letter case.
            int uc = 0;

            while (true)
            {
                //Determine if uppercase or lowercase by random number.
                if (_random.Next(2) == 1)
                {
                    //Adds 97 to the ASCII char dec value, making the character undercase.
                    uc = 97;
                }
                else
                {
                    //Adds 65 to the ASCII char dec value, making the character uppercase.
                    uc = 65;
                }

                //Print a char from A-Z or a-z, depending on "uc"'s value.
                char key = (char)(_random.Next(25) + uc);

                //Send the char's input.
                SendKeys.SendWait(key.ToString());

                //Wait between 0.5 and 1.5 seconds to reiterate loop.
                Thread.Sleep(_random.Next(1000) + 500);
            }
        }

        /// <summary>
        /// Generates random system sounds.
        /// </summary>
        static void SoundThread()
        {
            Console.WriteLine("SoundThread Running.");

            while (true)
            {
                //20% chance per second to make a system sound from the available 5.
                if (_random.Next(100) > 89)
                {
                    //Choose sound based on RNG.
                    switch (_random.Next(5))
                    {
                        case 0:
                            SystemSounds.Asterisk.Play();
                            break;

                        case 1:
                            SystemSounds.Beep.Play();
                            break;

                        case 2:
                            SystemSounds.Exclamation.Play();
                            break;

                        case 3:
                            SystemSounds.Hand.Play();
                            break;

                        case 4:
                            SystemSounds.Question.Play();
                            break;
                    }
                }

                //Sleep for half a second (DOESN'T ALWAYS PLAY, SO RNG HERE IS USELESS).
                Thread.Sleep(500);
            }
        }

        /// <summary>
        /// Generates random popup prompt windows.
        /// </summary>
        static void PopupThread()
        {
            Console.WriteLine("PopupThread Running.");

            while (true)
            {
                switch (_random.Next(3))
                {
                    case 0:
                        MessageBox.Show("explorer.exe has stopped working. Please reseat your RAM to fix.", "explorer.exe has stopped responding.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 1:
                        MessageBox.Show("Your C:/ drive is c̘̻͚̙̲̲̺̄̎̀̿̀̽ͮo̽҉̩̣̜̩̞r̴̪̫̺͉̯̙̦̾̍r̳͇̣̦̊ǘ̔̈́̆̽̽p͒ͥ҉̱̻̮̮̱ț̶͎̍ͤe͂̋̀͌ͣ̇̄ḑ͔̹̦͖̙̥̐̏ͭ̐ͅ, p̶̲̟̳̤̳͔̱͎͍͈̫̹̖͙̗̎̔́̈́̀́ͅl̵̢̛̩̥̳͈̯͍̣̝͖͚̜̖͓̗̾ͯ̎ͯ̒͑ͨ͛̂͒̽̀̀͟e̷̛̖̲̭͈̺͓͖̞̩̯̗ͨͭͧ̑́́͜aͭ̃ͨ͏̵̧̺͖̪͓̰̗̪͕̣̖̘̺͚͍͎̝̩̕͝ͅş̶̥͇̹͔̜͖̟̝̪͙̘̪̬̞͔̦̗ͬ͊͂͂̌̽͘ë̲͔̫̖́̿̌͊̐̒̎͜͠ ͌͛ͫ̓͑ͭͬ͑̈́̅̑҉̦̩͕̲̘̪͇̪̫̹̪͉̖̞̗̞͎́K̡̯̺̤̣̼̙͍̱͔̪͍̤̱̤̙̗͍ͪ̋ͤ͊͛̀̀͘ͅͅÍ̡̠̠̩̠̯̙̟̱ͦ͆ͨ͛̾̿ͪ̍̆̂̑̆̽̏̽̒͌̃Ĺ͒̄̄̚҉̵̢҉̶̤͓̞͎͈̖̪̲Ļ̦̺͖̠̰̯̲̮͍̉͛̃ͭ̔͂̿̅ͩ̄̑͑͒ ̵̛̮͍̙̟̟ͭ̓̂͐ͦ̏̇̏͛̄̆͆͛͠M̄͛̉̅ͧͨͨ͑͆̑͐͜͡͏͍̹̪̜̠̗͕͓̘̖͚̯̖̜ͅE͂ͪ̓̽̌͆̋ͣ́ͭͣͧ̊̾͗ͯ̚͜͞͏̠̗̤̫̲͙̫̘͓͕̰̩͚̰̥̗͞.̵̡̝͖̺͙ͨͦ̐͂͋̓ͧͣ͡", "CRITICAL SYSTEM ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 2:
                        MessageBox.Show("Your disk drive has stopped runni", "Disk halted unexpectedly.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }

                //Sleep from 10 seconds to 15 seconds.
                Thread.Sleep(_random.Next(5000) + 10000);
            }
        }
    }
}
