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
                string audioFilePath = @"C:\Users\Khutjo Mamabolo\Desktop\Shieldify\Shieldify\Audio\bob.wav";
                SoundPlayer player = new SoundPlayer(audioFilePath);
                player.PlaySync();// Play the audio file
            }
            catch (Exception ex) // Error should Audio be unable to play
            {
                Console.WriteLine("Error playing audio: " + ex.Message);
            }
        }

        static void Conversation() //Creating the conversation
        {
            string name;

            Console.WriteLine($"Bob: Hello, I am Bob, your personal security assistant. What is your name?");
            name = Console.ReadLine();

            Console.WriteLine($"Bob: Hello " + name + ", how can I help you today?");

            while (true) // Continue the conversation until the user exits
            {
                string userInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userInput))
                { 
                    Console.WriteLine("Bob: I'm sorry, I didn't quite catch that. Can you please repeat?");
                }

                else if (userInput.ToLower().Contains("How are you") || userInput.ToLower().Contains("How are you today") || userInput.ToLower().Contains("How are you?")|| userInput.ToLower().Contains("How are you today?"))
                {
                    Console.WriteLine("Bob: I'm just a program, but I'm running smoothly! How can I assist you?");
                }

                else if (userInput.ToLower().Contains("hello") || userInput.ToLower().Contains("hi"))
                {
                    Console.WriteLine("Bob: Hello! How can I help you today?");
                }

                else if (userInput.ToLower().Contains("what is your name") || userInput.ToLower().Contains("who are you"))
                {
                    Console.WriteLine("Bob: My name is Bob, your personal security assistant.");
                }

                else if (userInput.ToLower().Contains("purpose") || userInput.ToLower().Contains("what do you do") || userInput.ToLower().Contains("job") || userInput.ToLower().Contains("role"))
                {
                    Console.WriteLine("Bob: My purpose is to provide cybersecurity advice and help you stay safe online.");
                    Console.WriteLine("Bob: I can guide you on password safety, spotting phishing scams, and best practices for safe browsing.");
                    Console.WriteLine("Bob: Cyber threats are always evolving, so staying informed is key to protecting your personal information.");
                    Console.WriteLine("Bob: Feel free to ask me about any cybersecurity concerns you have;)");

                }

                else if (userInput.ToLower().Contains("ask") || userInput.ToLower().Contains("help") )
                {
                    Console.WriteLine("Bob: I'm here to help you stay safe online! You can ask me about:");
                    Console.WriteLine("Bob: 🔹 Password safety – Learn how to create strong and secure passwords.");
                    Console.WriteLine("Bob: 🔹 Phishing scams – How to recognize and avoid fake emails and websites.");
                    Console.WriteLine("Bob: 🔹 Safe browsing – Tips to protect yourself from online threats.");
                    Console.WriteLine("Bob: If you need help with something else, feel free to ask!");
                }

                else if (userInput.ToLower().Contains("password"))
                {
                    Console.WriteLine("Bob: A strong password is your first defense against hackers. Here are some tips to keep your accounts secure:");
                    Console.WriteLine("Bob: 1️. Use a password with at least 12 characters, including uppercase and lowercase letters, numbers, and special symbols.");
                    Console.WriteLine("Bob: 2️. Avoid using the same password for multiple accounts. If one gets compromised, others will stay safe.");
                    Console.WriteLine("Bob: 3️. Never use easily guessable passwords like '123456', 'password', or your birthdate.");
                    Console.WriteLine("Bob: 4️. Consider using a password manager to store and generate strong passwords securely.");
                    Console.WriteLine("Bob: 5️. Enable multi-factor authentication (MFA) whenever possible for extra security.");
                }

                else if (userInput.ToLower().Contains("phishing"))
                {
                    Console.WriteLine("Bob: Phishing is a type of cyberattack where scammers trick you into revealing personal information, such as passwords or banking details.");
                    Console.WriteLine("Bob: This is often done through fake emails, messages, or websites that look legitimate.");
                    Console.WriteLine("Bob: To stay safe, never click on suspicious links, double-check sender addresses, and avoid downloading unknown attachments.");
                    Console.WriteLine("Bob: Always verify websites before entering sensitive information and use multi-factor authentication for extra security.");
                }
           
                else if (userInput.ToLower().Contains("browsing"))
                {
                    Console.WriteLine("Bob: Safe browsing helps protect you from hackers and malicious websites. Here are some key tips:");
                    Console.WriteLine("Bob: 1️. Always check the website's URL before entering sensitive information. Look for 'https://'—the 's' means the site is secure.");
                    Console.WriteLine("Bob: 2️. Avoid clicking on pop-ups or unknown links, as they may lead to harmful sites.");
                    Console.WriteLine("Bob: 3️. Never enter personal or financial details on suspicious or unsecured websites.");
                    Console.WriteLine("Bob: 4️. Avoid using public Wi-Fi for banking or important transactions—hackers can intercept your data.");
                    Console.WriteLine("Bob: 5️. Keep your browser and antivirus software updated to protect against security threats.");
                }

                else if (userInput.ToLower().Contains("encryption"))
                {
                    Console.WriteLine("Bob: Encryption is the process of converting data into a code to prevent unauthorized access. It’s used to protect sensitive data like passwords, bank details, and credit card information." +  
                        " Encryption makes data unreadable to anyone without the correct decryption key, ensuring privacy and security even if the data is intercepted.");
                    Console.WriteLine("Bob: There are different types of encryption, such as symmetric (same key for encryption and decryption) and asymmetric (public and private keys). Common algorithms include AES (Advanced Encryption Standard) and RSA.");
                }

                else if (userInput.ToLower().Contains("firewall"))
                {
                    Console.WriteLine("Bob: A firewall is a security system that monitors and controls incoming and outgoing network traffic based on predetermined security rules." +
                        " It acts as a barrier between your device or network and potential threats from the internet or other untrusted sources.");
                    Console.WriteLine("Bob: Firewalls can be hardware-based, software-based, or both. They help protect devices from hackers, malware, and other types of cyberattacks. Modern firewalls also provide features like intrusion detection and prevention.");
                }

                else if (userInput.ToLower().Contains("antivirus"))
                {
                    Console.WriteLine("Bob: Antivirus software helps protect your device from viruses, malware, and other online threats by scanning files and programs for known threats and quarantining suspicious ones.");
                    Console.WriteLine("Bob: It’s important to keep your antivirus software updated regularly to ensure it can recognize and protect against the latest threats. " +
                        "Some antivirus software also includes additional features like web protection, email scanning, and firewall capabilities.");
                }

                else if (userInput.ToLower().Contains("malware"))
                {
                    Console.WriteLine("Bob: Malware is malicious software designed to harm your device, steal your data, or perform unauthorized actions. It includes a variety of types like viruses, worms, ransomware, spyware, adware, and Trojans.");
                    Console.WriteLine("Bob: Malware can be spread through infected emails, websites, and software downloads. To protect against malware, avoid downloading files from untrusted sources, keep your software up to date, and use antivirus software.");
                }

                else if (userInput.ToLower().Contains("ransomware"))
                {
                    Console.WriteLine("Bob: Ransomware is a type of malware that encrypts your files and demands payment, usually in cryptocurrency, to restore access. It can be delivered through phishing emails, malicious websites, or software vulnerabilities.");
                    Console.WriteLine("Bob: Prevention tips include avoiding suspicious email attachments or links, regularly backing up your data, and keeping your system and software up to date to patch vulnerabilities.");
                }
                        
                else if (userInput.ToLower().Contains("social engineering"))
                {
                    Console.WriteLine("Bob: Social engineering is a tactic used by cybercriminals to manipulate individuals into divulging confidential information, typically through psychological manipulation or deceit.");
                    Console.WriteLine("Bob: Common methods include pretexting (posing as a trusted person), baiting (offering something enticing to gain access), and tailgating (following someone into a secure area)." +
                        " Always be cautious about unsolicited requests and verify their legitimacy.");
                }

                else if (userInput.ToLower().Contains("two-factor authentication") || userInput.ToLower().Contains("2fa"))
                {
                    Console.WriteLine("Bob: Two-factor authentication (2FA) adds an extra layer of security to your accounts by requiring not only a password but also a second form of verification, like a one-time code sent to your phone or an authentication app.");
                    Console.WriteLine("Bob: This helps prevent unauthorized access, even if your password is compromised. Common forms of 2FA include SMS codes, authentication apps (like Google Authenticator), or biometric methods like fingerprints.");
                }

                else if (userInput.ToLower().Contains("data breach"))
                {
                    Console.WriteLine("Bob: A data breach occurs when sensitive, protected, or confidential data is accessed, stolen, or disclosed without authorization. This can happen through hacking, insider threats, or poor security practices.");
                    Console.WriteLine("Bob: If you’ve been affected by a data breach, it's important to change passwords, monitor accounts for suspicious activity, and consider credit monitoring. Using strong, unique passwords and enabling 2FA can help protect your accounts.");
                }

                else if (userInput.ToLower().Contains("cybersecurity"))
                {
                    Console.WriteLine("Bob: Cybersecurity is the practice of protecting your devices, networks, and data from cyber threats like hackers, viruses, and malware. It involves using a variety of tools and practices to defend against attacks.");
                    Console.WriteLine("Bob: Effective cybersecurity includes using firewalls, antivirus software, encryption, secure passwords, safe browsing practices, and keeping your systems updated. Regularly reviewing your security settings is also important.");
                }

                else if (userInput.ToLower().Contains("vpn"))
                {
                    Console.WriteLine("Bob: A VPN (Virtual Private Network) is a service that creates a secure, encrypted connection between your device and the internet, making it harder for third parties to track your online activities.");
                    Console.WriteLine("Bob: VPNs are especially useful when using public Wi-Fi, as they protect your data from hackers. " +
                        "They also allow you to access region-restricted content by masking your IP address and making it appear as though you're in a different location.");
                }

                else if (userInput.ToLower().Contains("identity theft"))
                {
                    Console.WriteLine("Bob: Identity theft occurs when someone uses your personal information, such as your Social Security number, credit card details, or bank account information, to commit fraud or steal your identity.");
                    Console.WriteLine("Bob: To prevent identity theft, use strong passwords, avoid sharing sensitive information on unsecured websites, monitor your financial statements regularly, and consider using services like credit monitoring and fraud alerts.");
                }

                else if (userInput.ToLower().Contains("thank you") || userInput.Contains("thanks"))
                {
                    Console.WriteLine("Bob: You're welcome! Stay safe online, " + name + "!");
                }

                else if (userInput.ToLower().Contains("exit") || userInput.Contains("bye") || userInput.Contains("Leave"))
                {
                     Console.WriteLine($"Bob: Goodbye, {name}! Stay safe ;)");
                     break;
                }

                else
                {
                    Console.WriteLine("Bob: I'm still learning, but I'll try to assist you. ");
                }
              
            }

        }

    }
}