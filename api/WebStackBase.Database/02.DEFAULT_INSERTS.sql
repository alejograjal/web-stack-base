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

SET IDENTITY_INSERT [Review] ON;

INSERT INTO [Review]
(Id, Name, Email, [Comment], Rate, Created, ShowInWeb)
VALUES
(1,'Melissa Rodriguez', 'melirl86@gmail.com', 'Excellent, highly recommended. Allan is very professional and an excellent person.', 5, '2025-02-07', 1),
(2,'Curt Block', 'curtblock28@gmail.com', 'This was the best boat tour ever! I’m from Texas and I got to have monkeys on my shoulders eating out my hands! I got to see huge snakes and gorgeous birds!! Big Lizards! Great experience choose Alan he’s the best!!', 5, '2025-02-07', 1),
(3,'Linda Teler', 'telerlinda@gmail.com', 'Muy buena experiencia, los guias son muy atentos y amables y se nota, como intentan que nos llevemos una linda experiencia, con los animales y las vistas.', 5, '2025-02-15', 1),
(4,'Nico', 'Nicolendal43@Yahoo.com', 'Great tour and the our guide was 10/10 great experience', 5, '2025-02-15', 1),
(5,'Diego', 'dduprat23@yahoo.com', 'Awesome! So many wildlife and so much nature. The host was incredible! Great memories of our vacations!', 5, '2025-02-17', 1),
(6,'Elizabeth', 'shopgamez@hotmail.com', 'Excellent adventure! Alan was an amazing guide!!', 5, '2025-02-17', 1),
(7,'Alexei Pankin', 'alexei.pankin@gmail.com', 'We were very satisfied with the tour. It was amazing. Our tour guide Alan Mesen went above and beyond to show us all the animals along the river. We fed the monkeys, saw a baby crocodile, bats, lizards and racoons and a hawk. Thank you very much', 5, '2025-02-18', 1),
(8,'Arnaud', 'arnaud.sorel@orange.fr', 'Our guid was perfect. We have discovered the mangrove and the animals.', 5, '2025-02-26', 1),
(9,'Diane Martinez', 'dmartinez02@gmail.com', 'Great experience. Allen was an amazing guide. He was very knowledgeable.', 5, '2025-02-26', 1),
(10,'Marco', 'marco@dreskornfeld.de', 'Absolutely happy, even without the Monkeys at the end - that made it perfect though ;)', 5, '2025-02-28', 1),
(11,'Emori', 'emorisparkman0@gmail.com', '_', 4, '2025-03-03', 0),
(12,'Carlie Guthrie', 'carlieg98@yahoo.com', 'I’m from the US and we did the boat touring and we had a blast! Got to see so many cool animals, also had monkeys and birds eating out of our hands. Super cool to experience and our tour guide was wonderful and fun! 10/10 would go again.', 5, '2025-03-04', 1),
(13,'Karen Keating', 'kbkid55@gmail.com', 'Excellent tour. Alan was a great guide!  We saw a huge numbers of animals with him we could never have seen otherwise!!!!', 5, '2025-03-04', 1)

SET IDENTITY_INSERT [Review] OFF;

SET IDENTITY_INSERT [ResourceType] ON;

INSERT INTO [ResourceType]
(Id, [Name])
VALUES
(1, 'Home'),
(2, 'Gallery'),
(3, 'Tour');

SET IDENTITY_INSERT [ResourceType] OFF;


SET IDENTITY_INSERT [Resource] ON;

INSERT INTO Resource (Id, ResourceTypeId, Name, Description, Url, Path, IsEnabled, Created, CreatedBy, Updated, UpdatedBy, IsActive)
VALUES
(1, 1, 'Horse Ride With View', 'A photo titled "Horse Ride With View" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Horse_Ride_With_View.jpeg', 'Horse_Ride_With_View.jpeg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(2, 1, 'Raccon Sleeping', 'A photo titled "Raccon Sleeping" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Raccon_Sleeping.jpeg', 'Raccon_Sleeping.jpeg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(3, 1, 'River Tour', 'A photo titled "River Tour" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/River_Tour.jpg', 'River_Tour.jpg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(4, 1, 'Green Lizard', 'A photo titled "Green Lizard" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Green_Lizard.jpeg', 'Green_Lizard.jpeg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(5, 1, 'Giant Snake', 'A photo titled "Giant Snake" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Giant_Snake.jpeg', 'Giant_Snake.jpeg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(6, 1, 'Beach View', 'A photo titled "Beach View" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Beach_View.jpeg', 'Beach_View.jpeg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(7, 1, 'Waterfall Savegre', 'A photo titled "Waterfall Savegre" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Waterfall_Savegre.jpg', 'Waterfall_Savegre.jpg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(8, 1, 'Wild Bird', 'A photo titled "Wild Bird" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/WIld_Bird.jpeg', 'WIld_Bird.jpeg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(9, 1, 'Litle Snake', 'A photo titled "Litle Snake" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Litle_Snake.jpeg', 'Litle_Snake.jpeg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),

(10, 2, 'Palm Plantation', 'A photo titled "Palm Plantation" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Palm_Plantation.jpeg', 'Palm_Plantation.jpeg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(11, 2, 'Horse Ride Aventure', 'A photo titled "Horse Ride Aventure" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Horse_Ride_Aventure.jpeg', 'Horse_Ride_Aventure.jpeg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(12, 2, 'Giant Snake', 'A photo titled "Giant Snake" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Giant_Snake.jpeg', 'Giant_Snake.jpeg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(13, 2, 'Horse Ride', 'A photo titled "Horse Ride" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Horse_Ride.jpeg', 'Horse_Ride.jpeg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(14, 2, 'Horse View', 'A photo titled "Horse View" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Horse_View.jpeg', 'Horse_View.jpeg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(15, 2, 'Boat Tour', 'A photo titled "Boat Tour" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Boat_Tour.jpeg', 'Boat_Tour.jpeg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(16, 2, 'Up to Ocean', 'A photo titled "Up to Ocean" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/UpTop_Ocean.jpg', 'UpTop_Ocean.jpg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(17, 2, 'Monkey Visit', 'A photo titled "Monkey Visit" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Monkey_Visit.jpeg', 'Monkey_Visit.jpeg', 1, '2025-04-19 22:32:54.033', 'admin', NULL, NULL, 1),
(18, 2, 'Opposum Night', 'A photo titled "Opposum Night" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Opposum_Night.jpeg', 'Opposum_Night.jpeg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(19, 2, 'Beach View', 'A photo titled "Beach View" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Beach_View.jpeg', 'Beach_View.jpeg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(20, 2, 'Waterfall Swim', 'A photo titled "Waterfall Swim" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Waterfall_Swim.jpg', 'Waterfall_Swim.jpg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(21, 2, 'Snake', 'A photo titled "Snake" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Snake.jpeg', 'Snake.jpeg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(22, 2, 'Snake Search', 'A photo titled "Snake Search" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Snake_Search.jpeg', 'Snake_Search.jpeg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(23, 2, 'Waterfall Savegre', 'A photo titled "Waterfall Savegre" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Waterfall_Savegre.jpg', 'Waterfall_Savegre.jpg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),

(24, 3, 'Green Lizard', 'A photo titled "Green Lizard" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Green_Lizard.jpeg', 'Green_Lizard.jpeg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(25, 3, 'Crocodile Night', 'A photo titled "Crocodile Night" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Crocodile_Night.jpeg', 'Crocodile_Night.jpeg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(26, 3, 'Small Crocodile', 'A photo titled "Small Crocodile" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Small_Crocodile.jpeg', 'Small_Crocodile.jpeg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(27, 3, 'Raccon Sleeping', 'A photo titled "Raccon Sleeping" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Raccon_Sleeping.jpeg', 'Raccon_Sleeping.jpeg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(28, 3, 'Wild Bird', 'A photo titled "Wild Bird" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/WIld_Bird.jpeg', 'WIld_Bird.jpeg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(29, 3, 'Night Birds View', 'A photo titled "Night Birds View" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Night_Birds_View.jpeg', 'Night_Birds_View.jpeg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(30, 3, 'Heron Night', 'A photo titled "Heron Night" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Heron_Night.jpeg', 'Heron_Nigh.jpeg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(31, 3, 'Hidden Snake', 'A photo titled "Hidden Snake" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Hidden_Snake.jpeg', 'Hidden_Snake.jpeg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(32, 3, 'Crocodile Eyes', 'A photo titled "Crocodile Eyes" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Crocodile_Eyes.jpeg', 'Crocodile_Eyes.jpeg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(33, 3, 'Little Bird Tree', 'A photo titled "Little Bird Tree" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Little_Bird_Tree.jpeg', 'Little_Bird_Tree.jpeg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(34, 3, 'Litle Snake', 'A photo titled "Litle Snake" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Litle_Snake.jpeg', 'Litle_Snake.jpeg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(35, 3, 'Bird', 'A photo titled "Bird" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Bird.jpeg', 'Bird.jpeg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),

(36, 3, 'Waterfall Savegre', 'A photo titled "Waterfall Savegre" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Waterfall_Savegre.jpg', 'Waterfall_Savegre.jpg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(37, 3, 'Rive Tour', 'A photo titled "Rive Tour" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Rive_Tour.jpg', 'Rive_Tour.jpg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(38, 3, 'Waterfall Swim', 'A photo titled "Waterfall Swim" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Waterfall_Swim.jpg', 'Waterfall_Swim.jpg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(39, 3, 'Waterfall', 'A photo titled "Waterfall" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Waterfall.jpg', 'Waterfall.jpg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),

(40, 3, 'Beach View', 'A photo titled "Beach View" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Beach_View.jpeg', 'Beach_View.jpeg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(41, 3, 'Mountain', 'A photo titled "Mountain" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Mountain.jpg', 'Mountain.jpg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(42, 3, 'Mountain View', 'A photo titled "Mountain View" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Mountain_View.jpeg', 'Mountain_View.jpeg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(43, 3, 'Road Trip', 'A photo titled "Road Trip" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Road_Trip.jpg', 'Road_Trip.jpg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),

(44, 3, 'Coyol', 'A photo titled "Coyol" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Coyol.jpg', 'Coyol.jpg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(45, 3, 'Palm Plantation', 'A photo titled "Palm Plantation" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Palm_Plantation.jpeg', 'Palm_Plantation.jpeg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(46, 3, 'Palm Plantation Tour', 'A photo titled "Palm Plantation Tour" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Palm_Plantation_Tour.jpg', 'Palm_Plantation_Tour.jpg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(47, 3, 'Ocean View With Palm', 'A photo titled "Ocean View With Palm" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Ocean_View_With_Palm.jpg', 'Ocean_View_With_Palm.jpg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),

(48, 3, 'Boat Tour', 'A photo titled "Boat Tour" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Boat_Tour.jpeg', 'Boat_Tour.jpeg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(49, 3, 'Kayak Tour', 'A photo titled "Kayak Tour" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Kayak_Tour.jpeg', 'Kayak_Tour.jpeg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(50, 3, 'Giant Snake', 'A photo titled "Giant Snake" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Giant_Snake.jpeg', 'Giant_Snake.jpeg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(51, 3, 'Boat Tour Appreciation', 'A photo titled "Boat Tour Appreciation" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Boat_Tour_Appreciation.jpeg', 'Boat_Tour_Appreciation.jpeg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1),
(52, 3, 'Monkey Visit', 'A photo titled "Monkey Visit" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Monkey_Visit.jpeg', 'Monkey_Visit.jpeg', 1, '2025-04-19 22:32:54.033', 'admin', NULL, NULL, 1),
(53, 3, 'Snake', 'A photo titled "Snake" uploaded automatically.', 'https://manuelantonioexplorer.com:8080/gallery/Snake.jpeg', 'Snake.jpeg', 1, '2025-04-19T22:32:54.033', 'admin', NULL, NULL, 1)

SET IDENTITY_INSERT [Resource] OFF;

SET IDENTITY_INSERT [ServiceResource] ON;

INSERT INTO ServiceResource
(Id, ServiceId, ResourceId)
VALUES
(1, 1, 24),
(2, 1, 25),
(3, 1, 26),
(4, 1, 27),
(5, 1, 28),
(6, 1, 29),
(7, 1, 30),
(8, 1, 31),
(9, 1, 32),
(10, 1, 33),
(11, 1, 34),
(12, 1, 35),

(13, 2, 36),
(14, 2, 37),
(15, 2, 38),
(16, 2, 39),

(17, 3, 40),
(18, 3, 41),
(19, 3, 42),
(20, 3, 43),


(21, 4, 44),
(22, 4, 45),
(23, 4, 46),
(24, 4, 47),

(25, 5, 48),
(26, 5, 49),
(27, 5, 50),
(28, 5, 51),
(29, 5, 52),
(30, 5, 53)

SET IDENTITY_INSERT [ServiceResource] OFF;