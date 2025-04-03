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
                string audioFilePath = @"C:\Users\Khutjo Mamabolo\Desktop\Shieldify\Shieldify\Audio\bob.wav";
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
            string name;

            TypingEffect($"Bob: Hello, I am Bob, your personal security assistant. What is your name?");
            name = Console.ReadLine();
            Console.WriteLine(" ");

            TypingEffect($"Bob: Hello " + name + ", how can I help you today?");
            Console.WriteLine(" ");

            while (true) // Continue the conversation until the user exits
            {
                string userInput = Console.ReadLine();
                string userInputLower = userInput.ToLower().Trim();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    TypingEffect("Bob: I'm sorry, I didn't quite catch that. Can you please repeat?");
                    Console.WriteLine(" ");
                    continue;
                }

                switch (userInputLower)
                {
                    case string input when input.Contains("hello") || input.Contains("hi"):
                        Console.ForegroundColor = ConsoleColor.Green;
                        TypingEffect("Bob: Hello! How can I help you today?");
                        Console.ResetColor();
                        break;

                    case string input when input.Contains("how are you") || input.Contains("how are you today") || input.Contains("how are you?"):
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        TypingEffect("Bob: I'm just a program, but I'm running smoothly! How can I assist you?");
                        Console.ResetColor();
                        break;

                    case string input when input.Contains("what is your name") || input.Contains("who are you"):
                        Console.ForegroundColor = ConsoleColor.Green;
                        TypingEffect("Bob: My name is Bob, your personal security assistant.");
                        Console.ResetColor();
                        break;

                    case string input when input.Contains("purpose") || input.Contains("what do you do") || input.Contains("job") || input.Contains("role"):
                        Console.ForegroundColor = ConsoleColor.Blue;
                        TypingEffect("Bob: My purpose is to provide cybersecurity advice and help you stay safe online.");
                        TypingEffect("Bob: I can guide you on password safety, spotting phishing scams, and best practices for safe browsing.");
                        TypingEffect("Bob: Cyber threats are always evolving, so staying informed is key to protecting your personal information.");
                        TypingEffect("Bob: Feel free to ask me about any cybersecurity concerns you have;)");
                        Console.ResetColor();
                        break;

                    case string input when input.Contains("ask") || input.Contains("help"):
                        Console.ForegroundColor = ConsoleColor.Green;
                        TypingEffect("Bob: I'm here to help you stay safe online! You can ask me about:");
                        TypingEffect("Bob: 🔹 Password safety – Learn how to create strong and secure passwords.");
                        TypingEffect("Bob: 🔹 Phishing scams – How to recognize and avoid fake emails and websites.");
                        TypingEffect("Bob: 🔹 Safe browsing – Tips to protect yourself from online threats.");
                        TypingEffect("Bob: If you need help with something else, feel free to ask!");
                        Console.ResetColor();
                        break;

                    case string input when input.Contains("password"):
                        Console.ForegroundColor = ConsoleColor.Red;
                        TypingEffect("Bob: A strong password is your first defense against hackers. Here are some tips to keep your accounts secure:");
                        TypingEffect("Bob: 1️. Use a password with at least 12 characters, including uppercase and lowercase letters, numbers, and special symbols.");
                        TypingEffect("Bob: 2️. Avoid using the same password for multiple accounts. If one gets compromised, others will stay safe.");
                        TypingEffect("Bob: 3️. Never use easily guessable passwords like '123456', 'password', or your birthdate.");
                        TypingEffect("Bob: 4️. Consider using a password manager to store and generate strong passwords securely.");
                        TypingEffect("Bob: 5️. Enable multi-factor authentication (MFA) whenever possible for extra security.");
                        Console.ResetColor();
                        break;

                    case string input when input.Contains("phishing"):
                        Console.ForegroundColor = ConsoleColor.Red;
                        TypingEffect("Bob: Phishing is a type of cyberattack where scammers trick you into revealing personal information, such as passwords or banking details.");
                        TypingEffect("Bob: This is often done through fake emails, messages, or websites that look legitimate.");
                        TypingEffect("Bob: To stay safe, never click on suspicious links, double-check sender addresses, and avoid downloading unknown attachments.");
                        TypingEffect("Bob: Always verify websites before entering sensitive information and use multi-factor authentication for extra security.");
                        Console.ResetColor();
                        break;

                    case string input when input.Contains("browsing"):
                        Console.ForegroundColor = ConsoleColor.Blue;
                        TypingEffect("Bob: Safe browsing helps protect you from hackers and malicious websites. Here are some key tips:");
                        TypingEffect("Bob: 1️. Always check the website's URL before entering sensitive information. Look for 'https://'—the 's' means the site is secure.");
                        TypingEffect("Bob: 2️. Avoid clicking on pop-ups or unknown links, as they may lead to harmful sites.");
                        TypingEffect("Bob: 3️. Never enter personal or financial details on suspicious or unsecured websites.");
                        TypingEffect("Bob: 4️. Avoid using public Wi-Fi for banking or important transactions—hackers can intercept your data.");
                        TypingEffect("Bob: 5️. Keep your browser and antivirus software updated to protect against security threats.");
                        Console.ResetColor();
                        break;

                    case string input when input.Contains("encryption"):
                        Console.ForegroundColor = ConsoleColor.Green;
                        TypingEffect("Bob: Encryption is the process of converting data into a code to prevent unauthorized access. It’s used to protect sensitive data like passwords, bank details, and credit card information." +
                            " Encryption makes data unreadable to anyone without the correct decryption key, ensuring privacy and security even if the data is intercepted.");
                        TypingEffect("Bob: There are different types of encryption, such as symmetric (same key for encryption and decryption) and asymmetric (public and private keys). Common algorithms include AES (Advanced Encryption Standard) and RSA.");
                        Console.ResetColor();
                        break;

                    case string input when input.Contains("firewall"):
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        TypingEffect("Bob: A firewall is a security system that monitors and controls incoming and outgoing network traffic based on predetermined security rules." +
                            " It acts as a barrier between your device or network and potential threats from the internet or other untrusted sources.");
                        TypingEffect("Bob: Firewalls can be hardware-based, software-based, or both. They help protect devices from hackers, malware, and other types of cyberattacks. Modern firewalls also provide features like intrusion detection and prevention.");
                        Console.ResetColor();
                        break;

                    case string input when input.Contains("antivirus"):
                        Console.ForegroundColor = ConsoleColor.Green;
                        TypingEffect("Bob: Antivirus software helps protect your device from viruses, malware, and other online threats by scanning files and programs for known threats and quarantining suspicious ones.");
                        TypingEffect("Bob: It’s important to keep your antivirus software updated regularly to ensure it can recognize and protect against the latest threats. " +
                            "Some antivirus software also includes additional features like web protection, email scanning, and firewall capabilities.");
                        Console.ResetColor();
                        break;

                    case string input when input.Contains("malware"):
                        Console.ForegroundColor = ConsoleColor.Blue;
                        TypingEffect("Bob: Malware is malicious software designed to harm your device, steal your data, or perform unauthorized actions. It includes a variety of types like viruses, worms, ransomware, spyware, adware, and Trojans.");
                        TypingEffect("Bob: Malware can be spread through infected emails, websites, and software downloads. To protect against malware, avoid downloading files from untrusted sources, keep your software up to date, and use antivirus software.");
                        Console.ResetColor();
                        break;

                    case string input when input.Contains("ransomware"):
                        Console.ForegroundColor = ConsoleColor.Green;
                        TypingEffect("Bob: Ransomware is a type of malware that encrypts your files and demands payment, usually in cryptocurrency, to restore access. It can be delivered through phishing emails, malicious websites, or software vulnerabilities.");
                        TypingEffect("Bob: Prevention tips include avoiding suspicious email attachments or links, regularly backing up your data, and keeping your system and software up to date to patch vulnerabilities.");
                        Console.ResetColor();
                        break;

                    case string input when input.Contains("social engineering"):
                        Console.ForegroundColor = ConsoleColor.Green;
                        TypingEffect("Bob: Social engineering is a tactic used by cybercriminals to manipulate individuals into divulging confidential information, typically through psychological manipulation or deceit.");
                        TypingEffect("Bob: Common methods include pretexting (posing as a trusted person), baiting (offering something enticing to gain access), and tailgating (following someone into a secure area)." +
                            " Always be cautious about unsolicited requests and verify their legitimacy.");
                        Console.ResetColor();
                        break;

                    case string input when input.Contains("two-factor authentication") || input.Contains("2fa"):
                        Console.ForegroundColor = ConsoleColor.Red;
                        TypingEffect("Bob: Two-factor authentication (2FA) adds an extra layer of security to your accounts by requiring not only a password but also a second form of verification, like a one-time code sent to your phone or an authentication app.");
                        TypingEffect("Bob: This helps prevent unauthorized access, even if your password is compromised. Common forms of 2FA include SMS codes, authentication apps (like Google Authenticator), or biometric methods like fingerprints.");
                        Console.ResetColor();
                        break;

                    case string input when input.Contains("data breach"):
                        Console.ForegroundColor = ConsoleColor.Red;
                        TypingEffect("Bob: A data breach occurs when sensitive, protected, or confidential data is accessed, stolen, or disclosed without authorization. This can happen through hacking, insider threats, or poor security practices.");
                        TypingEffect("Bob: If you’ve been affected by a data breach, it's important to change passwords, monitor accounts for suspicious activity, and consider credit monitoring. Using strong, unique passwords and enabling 2FA can help protect your accounts.");
                        Console.ResetColor();
                        break;

                    case string input when input.Contains("cybersecurity"):
                        Console.ForegroundColor = ConsoleColor.Blue;
                        TypingEffect("Bob: Cybersecurity is the practice of protecting your devices, networks, and data from cyber threats like hackers, viruses, and malware. It involves using a variety of tools and practices to defend against attacks.");
                        TypingEffect("Bob: Effective cybersecurity includes using firewalls, antivirus software, encryption, secure passwords, safe browsing practices, and keeping your systems updated. Regularly reviewing your security settings is also important.");
                        Console.ResetColor();
                        break;

                    case string input when input.Contains("vpn"):
                        Console.ForegroundColor = ConsoleColor.Red;
                        TypingEffect("Bob: A VPN (Virtual Private Network) is a service that creates a secure, encrypted connection between your device and the internet, making it harder for third parties to track your online activities.");
                        TypingEffect("Bob: VPNs are especially useful when using public Wi-Fi, as they protect your data from hackers. " +
                            "They also allow you to access region-restricted content by masking your IP address and making it appear as though you're in a different location.");
                        Console.ResetColor();
                        break;

                    case string input when input.Contains("identity theft"):
                        Console.ForegroundColor = ConsoleColor.Red;
                        TypingEffect("Bob: Identity theft occurs when someone uses your personal information, such as your Social Security number, credit card details, or bank account information, to commit fraud or steal your identity.");
                        TypingEffect("Bob: To prevent identity theft, use strong passwords, avoid sharing sensitive information on unsecured websites, monitor your financial statements regularly, and consider using services like credit monitoring and fraud alerts.");
                        Console.ResetColor();
                        break;

                    case string input when input.Contains("thank you") || input.Contains("thanks"):
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        TypingEffect("Bob: You're welcome! Stay safe online, " + name + "!");
                        Console.ResetColor();
                        break;

                    case string input when input.Contains("exit") || input.Contains("bye") || input.Contains("leave"):
                        Console.ForegroundColor = ConsoleColor.Red;
                        TypingEffect($"Bob: Goodbye, {name}! Stay safe ;)");
                        Console.ResetColor();
                        return;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        TypingEffect("Bob: I'm still learning, but I'll try to assist you.");
                        Console.ResetColor();
                        break;
                }

                Console.WriteLine(" ");
            }
        }


    }
}