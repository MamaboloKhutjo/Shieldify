using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Shieldify
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayLogo();  // Display the ASCII logo
            PlayAudio();    // Play audio after displaying the logo
        }

        static void DisplayLogo()  //Creating the ASCII logo
        {
        Console.WriteLine(@"
                 ______     __  __     __     ______     __         _____     __     ______   __  __    
                /\  ___\   /\ \_\ \   /\ \   /\  ___\   /\ \       /\  __-.  /\ \   /\  ___\ /\ \_\ \   
                \ \___  \  \ \  __ \  \ \ \  \ \  __\   \ \ \____  \ \ \/\ \ \ \ \  \ \  __\ \ \____ \  
                 \/\_____\  \ \_\ \_\  \ \_\  \ \_____\  \ \_____\  \ \____-  \ \_\  \ \_\    \/\_____\ 
                  \/_____/   \/_/\/_/   \/_/   \/_____/   \/_____/   \/____/   \/_/   \/_/     \/_____/ 
                                                                                        
        "
        );

        }

        static void PlayAudio() //Uploading the Intro Audio
        {
            try
            {
                string audioFilePath = @"C:\Users\Khutjo Mamabolo\Desktop\C#\Shieldify\Shieldify\Audio\bob.wav";
                SoundPlayer player = new SoundPlayer(audioFilePath);
                player.PlaySync();// Play the audio file
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error playing audio: " + ex.Message);
            }
        }
    }
}