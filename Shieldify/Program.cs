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

        static Random random = new Random();
        static Dictionary<string, string> memory = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            DisplayLogo();  // Display the ASCII logo
            PlayAudio();    // Play audio after displaying the logo
            Conversation(); // Start the conversation
        }

        static void DisplayLogo()  //Creating the ASCII logo
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
                 ______     __  __     __     ______     __         _____     __     ______   __  __    
                /\  ___\   /\ \_\ \   /\ \   /\  ___\   /\ \       /\  __-.  /\ \   /\  ___\ /\ \_\ \   
                \ \___  \  \ \  __ \  \ \ \  \ \  __\   \ \ \____  \ \ \/\ \ \ \ \  \ \  __\ \ \____ \  
                 \/\_____\  \ \_\ \_\  \ \_\  \ \_____\  \ \_____\  \ \____-  \ \_\  \ \_\    \/\_____\ 
                  \/_____/   \/_/\/_/   \/_/   \/_____/   \/_____/   \/____/   \/_/   \/_/     \/_____/                                                                               
        ");
            Console.ResetColor();

        }

        static void PlayAudio() //Uploading the Intro Audio
        {
            try
            {
                string audioFilePath = @"\\Shieldify\Audio\bob.wav";
                SoundPlayer player = new SoundPlayer(audioFilePath);
                player.PlaySync();// Play the audio file
            }
            catch (Exception ex) // Error should Audio be unable to play
            {
                Console.WriteLine("Error playing audio: " + ex.Message);
            }
        }

        static void TypingEffect(string text, int delay = 30) // giving Bob the typing effect
        {
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(delay);
            }
            Console.WriteLine();
        }

        static void Conversation() //Creating the conversation
        {
            Console.WriteLine();
            TypingEffect("Bob: Hello, I am Bob, your personal security assistant. What is your name?");
            string name = Console.ReadLine();
            memory["name"] = name;

            Console.WriteLine();
            TypingEffect($"Bob: Nice to meet you, {name}! What's your favorite cybersecurity topic? (e.g. phishing, encryption, etc.)");
            string favTopic = Console.ReadLine();
            memory["favorite_topic"] = favTopic;

            TypingEffect($"Bob: Great! I’ll remember that you’re interested in {favTopic}. Let's continue!");

            Console.WriteLine();

            string currentTopic = null;

            while (true)
            {
                string userInput = Console.ReadLine()?.ToLower().Trim();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    TypingEffect("Bob: I'm sorry, I didn't quite catch that. Can you please repeat?");
                    continue;
                }

                if (userInput.Contains("hello") || userInput.Contains("hi"))
                {
                    TypingEffect($"Bob: Hello again, {memory["name"]}! How can I help you with {memory["favorite_topic"]} today?");
                    continue;
                }

                if (userInput.Contains("how are you"))
                {
                    TypingEffect("Bob: I'm just a program, but I'm running smoothly! How can I assist you?");
                    continue;
                }

                if (userInput.Contains("your name") || userInput.Contains("who are you"))
                {
                    TypingEffect("Bob: My name is Bob, your personal security assistant.");
                    continue;
                }

                if (userInput.Contains("bye") || userInput.Contains("quit") || userInput.Contains("exit"))
                {
                    TypingEffect($"Bob: It’s been a pleasure, {memory["name"]}. Stay safe and keep learning about {memory["favorite_topic"]}!");
                    break;
                }

                if ((userInput.Contains("more") || userInput.Contains("explain") || userInput.Contains("details") || userInput.Contains("don't understand") || userInput.Contains("not sure")) && currentTopic != null)
                {
                    string[] followUpResponses = responses[currentTopic];
                    string extra = followUpResponses[random.Next(followUpResponses.Length)];
                    TypingEffect($"Bob: Sure, let me explain more. {extra}");
                    continue;
                }

                bool found = false;
                foreach (var key in responses.Keys)
                {
                    if (userInput.Contains(key))
                    {
                        currentTopic = key;
                        string[] keyResponses = responses[key];
                        string response = keyResponses[random.Next(keyResponses.Length)];

                        TypingEffect($"Bob: {response}");

                        // Personalize based on favorite topic
                        if (key == memory["favorite_topic"].ToLower())
                        {
                            TypingEffect($"Bob: Since you're especially interested in {key}, I recommend keeping up with the latest news in that area.");
                        }

                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    TypingEffect($"Bob: I'm still learning, {memory["name"]}. Please ask me about topics like phishing, encryption, or your favorite topic: {memory["favorite_topic"]}.");
                }
            }
        }

        static Dictionary<string, string[]> responses = new Dictionary<string, string[]>
        {
            { "purpose", new[] {
                "I help you stay safe online by providing cybersecurity advice.",
                "I'm here to guide you on phishing, passwords, browsing safety, and more.",
                "My role is to educate and protect users from digital threats."
            }},
            { "help", new[] {
                "I can assist you with password safety, phishing awareness, and safe browsing tips.",
                "Ask me anything about online security – I'm here to help.",
                "Need help with cybersecurity? I'm at your service."
            }},
            { "password", new[] {
                "Use at least 12 characters with a mix of letters, numbers, and symbols.",
                "Never reuse passwords and always enable two-factor authentication.",
                "Avoid common passwords like '123456' or 'password'."
            }},
            { "phishing", new[] {
                "Always double-check URLs and email senders before clicking anything.",
                "Phishing scams often create urgency – stay calm and verify.",
                "Don't download attachments from unknown sources or click suspicious links."
            }},
            { "browsing", new[] {
                "Use HTTPS websites and avoid entering info on unsecured pages.",
                "Never click pop-ups offering free prizes – they're likely malicious.",
                "Avoid public Wi-Fi for banking or shopping. Use a VPN if possible."
            }},
            { "encryption", new[] {
                "Encryption protects your data by turning it into unreadable code.",
                "Common methods like AES and RSA keep sensitive data safe.",
                "It's crucial for online transactions and storing private data."
            }},
            { "firewall", new[] {
                "A firewall blocks unwanted traffic and protects your network.",
                "It's your first line of defense against cyberattacks.",
                "Use both software and hardware firewalls for best protection."
            }},
            { "antivirus", new[] {
                "Antivirus software scans for and removes malicious files.",
                "Keep it updated to stay protected against new threats.",
                "Run regular scans and avoid downloading unknown files."
            }},
            { "malware", new[] {
                "Malware includes viruses, spyware, and ransomware.",
                "Don't download software from untrusted sites.",
                "Keep your OS and security software updated."
            }},
            { "ransomware", new[] {
                "Ransomware locks your files and demands payment.",
                "Backup your data regularly and don’t open shady attachments.",
                "Use reputable antivirus and avoid suspicious links."
            }},
            { "social engineering", new[] {
                "Scammers may trick you into revealing info. Stay alert.",
                "Don't share passwords or personal data without verification.",
                "Even trusted-looking emails can be fake – verify first."
            }},
            { "vpn", new[] {
                "A VPN encrypts your internet traffic and hides your IP address.",
                "Use a VPN when using public Wi-Fi to protect your data.",
                "Not all VPNs are safe – choose a trusted, no-log provider."
            }},
            { "zero trust", new[] {
                "Zero Trust means never automatically trusting users or devices.",
                "Always verify identity before granting access to resources.",
                "It's a key strategy for reducing insider threats and breaches."
            }},
            { "data breach", new[] {
                "A data breach occurs when unauthorized users access private data.",
                "Use tools like HaveIBeenPwned to check if your email was exposed.",
                "Change passwords immediately after a breach and enable 2FA."
            }},
            { "cyber hygiene", new[] {
                "Cyber hygiene means following best practices to stay secure online.",
                "Regularly update software, use strong passwords, and avoid sketchy sites.",
                "Good habits help prevent malware, phishing, and identity theft."
            }},
            { "identity theft", new[] {
                "Cybercriminals can steal your personal info and impersonate you.",
                "Shred documents, avoid oversharing, and monitor your accounts.",
                "If you suspect identity theft, report it and freeze your credit."
            }},
            { "cyberbullying", new[] {
                "Cyberbullying is harassment done through digital means.",
                "Block bullies, save evidence, and report to trusted adults or platforms.",
                "Never respond aggressively – your safety and mental health come first."
            }},
            { "iot", new[] {
                "IoT devices like smart TVs or cameras can be hacked.",
                "Change default passwords and keep firmware updated.",
                "Place them on a separate network if possible for better safety."
            }},
            { "dark web", new[] {
                "The dark web is a hidden part of the internet used for anonymity.",
                "It's often linked to illegal activity, but also used for privacy.",
                "Never visit dark web sites without strong protection and legal knowledge."
            }},
            { "2fa", new[] {
                "Two-factor authentication adds a second layer of account security.",
                "Even if someone has your password, 2FA keeps your account safe.",
                "Use authentication apps or SMS codes for extra protection."
            }}
        };
    }
}



