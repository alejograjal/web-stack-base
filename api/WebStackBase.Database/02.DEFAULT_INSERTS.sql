USE WebStackBase;

SET IDENTITY_INSERT [Service] ON;

INSERT INTO [Service]
(Id, [Name], [Description], Cost, IsEnabled, IsActive, Created, CreatedBy)
VALUES
(1, 'Moonlit Mangrove Adventure at Damas Island: Explore by Boat', 'Explore the wonders of the Mangrove Forest on an extraordinary adventure through the diverse species of animals that thrive within this unique ecosystem, offered by the estuary of Damas Island. Step into the heart of the mangrove forest after dark and discover a world of wonder on our Nighttime Mangrove Adventure. Just 10 minutes from Quepos and Manuel Antonio, Damas Island provides a rare opportunity to explore one of Costa Rica’s most biodiverse ecosystems beneath the stars. As night falls, the forest comes alive with the sounds and sights of nocturnal wildlife, creating a thrilling and immersive experience. Led by expert guides, you’ll uncover the secrets of this magical environment, where creatures of all kinds become more active and visible under the cover of night. This 2 to 2.5-hour journey promises an unforgettable adventure into nature’s most captivating moments.', 0, 1, 1, GETDATE(), 'admin'),
(2, 'El Guabo River', 'Embark on a thrilling horseback adventure along the enchanting El Guabo River, where crystal-clear waters flow from the mountains, revealing the hidden beauty of Costa Rica’s natural wonders. Ride through lush landscapes and discover peaceful, secluded pools perfect for a refreshing dip. Surrounded by vibrant vegetation and pristine wilderness, this is an unforgettable experience that brings you closer to nature. Bring your family and experience the magic of El Guabo River—where adventure and serenity meet!', 0, 1, 1, GETDATE(), 'admin'),
(3, 'Nature Forest', 'Set off on a horseback journey across our expansive 50-hectare estate, where rugged mountains meet lush valleys and the Pacific Ocean stretches before you in all its glory. As you ride through diverse landscapes—from dense forests to sweeping meadows—experience the beauty and tranquility that only Costa Rica can offer. This is more than just a tour; it’s an invitation to connect with nature, discover hidden vistas, and forge memories that will stay with you forever. Come, embrace an adventure that takes you beyond horizons!', 0, 1, 1, GETDATE(), 'admin'),
(4, 'Palm oil plantation', 'Step into our estate, where adventure and education come together! On this exclusive tour, you’ll explore our palm oil plantation and learn about the fascinating process behind sustainable palm oil production in Costa Rica. From planting the seeds to harvesting the fruit, we’ll guide you through each step, revealing the complexities and importance of this vital industry. This enriching experience not only deepens your understanding of Costa Rican agriculture but also adds extraordinary value to your journey. Discover, learn, and create lasting memories with us!', 0, 1, 1, GETDATE(), 'admin'),
(5, 'Discover the Mangroves of Damas Island: A Daytime Boat Adventure', 'The mangrove forest is one of the most vital and fascinating ecosystems in the world, and Damas Island—just 10 minutes from Quepos and Manuel Antonio—boasts one of Costa Rica’s most extraordinary examples. This biodiversity hotspot is home to a rich array of wildlife, from vibrant birds and reptiles to crustaceans, mammals, and insects. Whether you choose to explore aboard our comfortable, fully equipped boats or embark on a guided kayak tour with our expert guides, you’ll get up close to the wonders of nature in a truly immersive way. With tours lasting 2 to 2.5 hours, you’re sure to experience an unforgettable journey into one of the planet’s most remarkable ecosystems.', 0, 1, 1, GETDATE(), 'admin')

SET IDENTITY_INSERT [Service] OFF;

SET IDENTITY_INSERT [CustomerFeedback] ON;

INSERT INTO [CustomerFeedback]
(Id, CustomerName, CustomerEmail, [Comment], Rating, Created, ShowInWeb)
VALUES
(1,'Melissa Rodriguez', 'melirl86@gmail.com', 'Excellent, highly recommended. Allan is very professional and an excellent person.', 5, GETDATE(), 1),
(2,'Curt Block', 'curtblock28@gmail.com', 'This was the best boat tour ever! I’m from Texas and I got to have monkeys on my shoulders eating out my hands! I got to see huge snakes and gorgeous birds!! Big Lizards! Great experience choose Alan he’s the best!!', 5, GETDATE(), 1),
(3,'Linda Teler', 'telerlinda@gmail.com', 'Muy buena experiencia, los guias son muy atentos y amables y se nota, como intentan que nos llevemos una linda experiencia, con los animales y las vistas.', 5, GETDATE(), 1),
(4,'Nico', 'Nicolendal43@Yahoo.com', 'Great tour and the our guide was 10/10 great experience', 5, GETDATE(), 1),
(5,'Diego', 'dduprat23@yahoo.com', 'Awesome! So many wildlife and so much nature. The host was incredible! Great memories of our vacations!', 5, GETDATE(), 1),
(6,'Elizabeth', 'shopgamez@hotmail.com', 'Excellent adventure! Alan was an amazing guide!!', 5, GETDATE(), 1),
(7,'Alexei Pankin', 'alexei.pankin@gmail.com', 'We were very satisfied with the tour. It was amazing. Our tour guide Alan Mesen went above and beyond to show us all the animals along the river. We fed the monkeys, saw a baby crocodile, bats, lizards and racoons and a hawk. Thank you very much', 5, GETDATE(), 1),
(8,'Arnaud', 'arnaud.sorel@orange.fr', 'Our guid was perfect. We have discovered the mangrove and the animals.', 5, GETDATE(), 1),
(9,'Diane Martinez', 'dmartinez02@gmail.com', 'Great experience. Allen was an amazing guide. He was very knowledgeable.', 5, GETDATE(), 1),
(10,'Marco', 'marco@dreskornfeld.de', 'Absolutely happy, even without the Monkeys at the end - that made it perfect though ;)', 5, GETDATE(), 1),
(11,'Emori', 'emorisparkman0@gmail.com', '_', 4, GETDATE(), 0),
(12,'Carlie Guthrie', 'carlieg98@yahoo.com', 'I’m from the US and we did the boat touring and we had a blast! Got to see so many cool animals, also had monkeys and birds eating out of our hands. Super cool to experience and our tour guide was wonderful and fun! 10/10 would go again.', 5, GETDATE(), 1),
(13,'Karen Keating', 'kbkid55@gmail.com', 'Excellent tour. Alan was a great guide!  We saw a huge numbers of animals with him we could never have seen otherwise!!!!', 5, GETDATE(), 1)

SET IDENTITY_INSERT [CustomerFeedback] OFF;
