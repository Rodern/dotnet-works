SET FOREIGN_KEY_CHECKS=0;

--
-- Table structure for table `category`
--

CREATE TABLE `category` (
  `categoryId` int NOT NULL,
  `name` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `code` varchar(6) COLLATE utf8mb4_general_ci NOT NULL,
  `icon` varchar(150) COLLATE utf8mb4_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `category`
--

INSERT INTO `category` (`categoryId`, `name`, `code`, `icon`) VALUES
(1, 'Detergent', '769845', 'https://static.vecteezy.com/system/resources/thumbnails/044/245/686/small_2x/colorful-laundry-detergent-bottles-with-clean-towels-png.png'),
(2, 'Beverages', '123456', 'https://th.bing.com/th/id/R.6df498052c293f34fd5ec7409a4bb808?rik=XSgxxlJT5Y4URQ&pid=ImgRaw&r=0'),
(3, 'Snacks', '234567', 'https://th.bing.com/th/id/OIP.hHadASAcAMzrcPs5eWU36AHaFb?cb=iwp2&rs=1&pid=ImgDetMain'),
(4, 'Personal Care', '345678', 'https://th.bing.com/th/id/R.01c302d771a4dbef782a52322864e0a0?rik=5cOHWFiI%2f5zgnQ&pid=ImgRaw&r=0'),
(5, 'Dairy Products', '456789', 'https://maolamilk.com/wp-content/uploads/2019/01/2Percent_Products_Group_1.30.png'),
(6, 'Bakery Goods', '567890', 'https://thegoldenlamb.com/wp-content/uploads/2023/06/Any-stale-bread-will-work-for-bread-pudding-1024x724.jpg'),
(7, 'Fresh Produce', '678901', 'https://th.bing.com/th/id/OIP.owDR8tth6F913R4ae54vyAHaE8?cb=iwp2&rs=1&pid=ImgDetMain'),
(8, 'Meat & Seafood', '789012', 'https://thumbs.dreamstime.com/b/assortment-meat-seafood-assortment-meat-seafood-beef-chicken-fish-pork-175696748.jpg'),
(9, 'Frozen Foods', '890123', 'https://th.bing.com/th/id/OIP.bUwNTqHSqGoihmmlVnB4vwHaE7?cb=iwp2&rs=1&pid=ImgDetMain'),
(10, 'Confectionery', '901234', 'https://www.centraldatacore.com/wp-content/uploads/Confectionery-Hard-Candy.jpg');

-- --------------------------------------------------------

--
-- Table structure for table `password`
--

CREATE TABLE `password` (
  `passwordId` int NOT NULL,
  `userId` int NOT NULL,
  `hashed` varchar(1000) COLLATE utf8mb4_general_ci NOT NULL,
  `salt` varbinary(128) NOT NULL,
  `last_changed` datetime NOT NULL,
  `past_passwords` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL COMMENT 'This field, takes a an object like \r\n\r\n[{\r\n "hashed" "string",\r\n "salt" : byte[]\r\n}\r\n]'
) ;

--
-- Dumping data for table `password`
--

INSERT INTO `password` (`passwordId`, `userId`, `hashed`, `salt`, `last_changed`, `past_passwords`) VALUES
(1, 8, '5D9C85D087D2972CD4212737182D1AEDCA8C85CC4C27EF87155F7FB492EA475F43B37B94238FDC1DD1C2F67DA78BCDB0C3453EA16751885316327B25B03CADD6E8F8B953A4F5DD8750970E3B0E0B0F1D226041EDFEBF678E9B2C7AB1C1F2B389390B6DFE0EF30E4DC1AB04D3E4F2C7BBD76FB06353BFEC051E879F46A615CDF6', 0x5cfbd1ef93ab7a19d8b1b9223b8d79335f043e141cf54a5a14ecf1db18d69ff00e4fa56b5f47c032cffce2804d0e09396a67981952da3c596be497595ed7eb4620fe0b4f2587c451d1093a6d8ff830937f54434b13f954aed39f66d046f570f7b9cb24274a287140fd468dc7d3536576b7ae594bc49a2591cec0e84ed02e3288, '2025-05-17 17:17:48', '[]'),
(2, 10, '1A60B9AAD1F39F9909AF2A4B949221A0D5FE098554044AF79E86E7E0DD7991F754C619325C72932A0D6B09C6B75BA4504BE56E1DA33BBB969B277D54B4ECB1D4053295054C7658D2909993578ADC0AA1E817F50F33306CD353E8526287D7B61217179E3ECD2E9B8F56AA011DB3A41785764623883DCFF769C82D36DCEFC3B7FE', 0x7aea1b128707eabc91e125fd3f46b6e0e52b03937d37129978cde27059a5b1f875e59a37a7c30b57e7cf9d9813f591766b9a195ff199f4aec96b54dcc05c1c3c908551df6b78970a368b38c3df929b8c6cafbc1de642d5385040f8b83bc0f46fa891aa165958c3f1d0de97b535d0518b99f711270a2ac26970ae7bcccdabf2ab, '2025-05-18 04:00:35', '[]');

-- --------------------------------------------------------

--
-- Table structure for table `product`
--

CREATE TABLE `product` (
  `productId` int NOT NULL,
  `categoryId` int DEFAULT NULL,
  `name` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `description` varchar(500) COLLATE utf8mb4_general_ci NOT NULL,
  `weight` float NOT NULL,
  `price` int NOT NULL,
  `in_stock` int NOT NULL,
  `image` varchar(150) COLLATE utf8mb4_general_ci NOT NULL,
  `created_at` datetime NOT NULL,
  `updated_at` datetime NOT NULL,
  `code` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `product`
--

INSERT INTO `product` (`productId`, `categoryId`, `name`, `description`, `weight`, `price`, `in_stock`, `image`, `created_at`, `updated_at`, `code`) VALUES
(1, 1, 'Omo', 'Unileverï¿½s largest detergent brand, OMO (also known as Persil, Skip or Surf Excel depending on where you live), believes you canï¿½t unleash your full potential without getting stuck in and getting dirty. So embrace the glory and the grime of every step on your journey to becoming your personal best. Weï¿½ll be there to wash it all off so you can go again. ', 5.435, 17621, 31, 'https://i5.walmartimages.com/asr/5e7d8696-7d4e-4ffc-990c-f11df888b7f1.d0b80396ac9b8568ae074db461fe6d7c.jpeg?odnHeight=640&odnWidth=640&odnBg=FFFFFF', '2025-05-18 10:25:18', '2025-05-18 10:25:18', 762345),
(2, 1, 'Ariel', 'Ariel detergent removes stubborn stains and ensures vibrant colors in every wash.', 5.5, 18501, 20, 'https://th.bing.com/th/id/R.da0e39d8a1fd94ad03156d5609fbfcac?rik=OJ21YMiQ6cBBsQ&pid=ImgRaw&r=0', '2025-05-18 10:30:00', '2025-05-18 10:30:00', 545098),
(4, 2, 'Coca-Cola', 'Classic Coca-Cola, a refreshing soft drink enjoyed by millions worldwide.', 0.33, 200, 100, 'https://mofongorest.com/wp-content/uploads/2021/09/COCACOLA.jpg', '2025-05-18 10:35:00', '2025-05-18 10:35:00', 102937),
(5, 2, 'Pepsi', 'Pepsi delivers a crisp, refreshing cola experience with a smooth finish.', 0.33, 240, 80, 'https://th.bing.com/th/id/OIP.gDKRcfYjof8ip_XGZTNjJAHaJu?cb=iwp2&rs=1&pid=ImgDetMain', '2025-05-18 10:40:00', '2025-05-18 10:40:00', 830989),
(6, 3, 'Lay\'s Classic Chips', 'Crispy potato chips with a perfect balance of salt and crunch.', 0.15, 300, 150, 'https://th.bing.com/th/id/R.ba611aa4ce966684f86d27a6751fa7ba?rik=kx7L%2btv72W%2bvaA&pid=ImgRaw&r=0', '2025-05-18 10:45:00', '2025-05-18 10:45:00', 912098),
(7, 3, 'Doritos Nacho Cheese', 'Bold and zesty Doritos with a rich nacho cheese flavor that excites your taste buds.', 0.2, 350, 120, 'https://media.nedigital.sg/fairprice/fpol/media/images/product/XL/10729188_XL1_20240110.jpg', '2025-05-18 10:50:00', '2025-05-18 10:50:00', 466801),
(8, 4, 'Dove Beauty Bar', 'Dove soap nurtures your skin with a gentle, hydrating formula for a soft feel.', 0.09, 151, 200, 'https://i5.walmartimages.com/asr/66791361-bef3-48c8-86ca-44b8208f053f_1.0206a9607bada187f8da1cb8f700c1a6.jpeg', '2025-05-18 10:55:00', '2025-05-18 10:55:00', 311297),
(9, 4, 'Nivea Moisturizing Cream', 'Nivea cream offers deep hydration, leaving your skin refreshed and smooth.', 0.25, 500, 150, 'https://th.bing.com/th/id/R.7da7784bc13df082fc50c75f4b1c51e1?rik=2m5eLUAVszsxuQ&pid=ImgRaw&r=0', '2025-05-18 11:00:00', '2025-05-18 11:00:00', 632560),
(10, 5, 'Amul Milk', 'Fresh and wholesome Amul milk, sourced from quality dairy farms for everyday nutrition.', 1, 300, 50, 'https://th.bing.com/th/id/OIP.jDTiD6yluHIu9zUFAHfNGQHaHa?cb=iwp2&rs=1&pid=ImgDetMain', '2025-05-18 11:05:00', '2025-05-18 11:05:00', 919036),
(11, 5, 'Alpen Yogurt', 'Creamy Alpen Yogurt, ideal for a healthy breakfast or a delightful snack.', 0.2, 121, 80, 'https://th.bing.com/th/id/R.0b738c30790223aeaf50f941e6a39a1b?rik=La7coOe5EX9lLw&pid=ImgRaw&r=0', '2025-05-18 11:10:00', '2025-05-18 11:10:00', 434567),
(12, 6, 'Wonder Bread', 'Wonder Bread offers a soft texture, perfect for making delightful sandwiches.', 0.5, 250, 60, 'https://i5.walmartimages.com/asr/5fee7417-0974-44da-a16c-155a1281fdaf_1.360b4f304b379c51fd98dc590701b4c9.jpeg', '2025-05-18 11:15:00', '2025-05-18 11:15:00', 651811),
(13, 6, 'Bimbo Rolls', 'Bimbo Rolls are light, flaky pastries perfect for a quick bite or a sweet treat.', 0.3, 180, 40, 'https://th.bing.com/th/id/OIP.9PjtwAEvt-cpDdKz9HFJOwHaHa?cb=iwp2&rs=1&pid=ImgDetMain', '2025-05-18 11:20:00', '2025-05-18 11:20:00', 190312),
(14, 7, 'Organic Apples', 'Crunchy and naturally sweet organic apples, perfect for snacking or baking.', 1, 400, 70, 'https://th.bing.com/th/id/OIP.Bt_8LhqSgf9A5Z1CCfsqrwHaE8?cb=iwp2&w=768&h=512&rs=1&pid=ImgDetMain', '2025-05-18 11:25:00', '2025-05-18 11:25:00', 878987),
(15, 7, 'Fresh Carrots', 'Fresh, crisp carrots packed with nutrients, ideal for salads and snacks.', 1, 200, 100, 'https://th.bing.com/th/id/OIP.NQoblU6aVDk4w-pjm_mqRgHaGD?cb=iwp2&rs=1&pid=ImgDetMain', '2025-05-18 11:30:00', '2025-05-18 11:30:00', 949196),
(16, 8, 'Chicken Breast', 'Lean chicken breast, a staple for healthy and versatile meal preparation.', 0.5, 1500, 40, 'https://th.bing.com/th/id/OIP.xTVqnZzj7ijX5xqGk-vazAHaHa?cb=iwp2&rs=1&pid=ImgDetMain', '2025-05-18 11:35:00', '2025-05-18 11:35:00', 500380),
(17, 8, 'Atlantic Salmon', 'Fresh Atlantic Salmon, known for its rich omega-3 fatty acids and robust flavor.', 0.75, 3500, 25, 'https://th.bing.com/th/id/R.1167e74f1a9b284649fe46ddebb6f632?rik=frWY3BvnrG58cg&pid=ImgRaw&r=0', '2025-05-18 11:40:00', '2025-05-18 11:40:00', 861016),
(18, 9, 'Pepperoni Pizza', 'A ready-to-bake pepperoni pizza with a crispy crust and savory toppings.', 0.8, 2500, 30, 'https://th.bing.com/th/id/OIP.ydICQiGCRZECpd96F2D8pAHaFN?cb=iwp2&rs=1&pid=ImgDetMain', '2025-05-18 11:45:00', '2025-05-18 11:45:00', 831700),
(19, 9, 'Frozen Mixed Vegetables', 'A nutritious mix of frozen vegetables ready to enhance your meals.', 1, 1800, 50, 'https://th.bing.com/th/id/OIP.zypUdPBUTKT30vsYMalduwHaHa?cb=iwp2&rs=1&pid=ImgDetMain', '2025-05-18 11:50:00', '2025-05-18 11:50:00', 304567),
(20, 10, 'Cadbury Chocolate', 'Rich and creamy Cadbury chocolate crafted for moments of indulgence.', 0.1, 300, 90, 'https://th.bing.com/th/id/R.8265f5c712093d4e576a782248e4bdc9?rik=f0%2fezu6HQWSNRg&pid=ImgRaw&r=0', '2025-05-18 11:55:00', '2025-05-18 11:55:00', 703873),
(21, 10, 'Mars Bar', 'A timeless treat, Mars Bar combines caramel, nougat, and chocolate into a delicious snack.', 0.12, 350, 75, 'https://th.bing.com/th/id/OIP.3vTW6beDGuIZutP71jS9JAHaHa?cb=iwp2&rs=1&pid=ImgDetMain', '2025-05-18 12:00:00', '2025-05-18 12:00:00', 331020);

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `userId` int NOT NULL,
  `name` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `email` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `role` enum('User','Admin','Dev') COLLATE utf8mb4_general_ci NOT NULL,
  `created_at` datetime NOT NULL,
  `updated_at` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`userId`, `name`, `email`, `role`, `created_at`, `updated_at`) VALUES
(8, 'string', 'fpsbi@ghb.cm', 'User', '2025-05-17 17:17:46', '2025-05-17 17:17:46'),
(10, 'Jason Ma', 'jason@mail.com', 'User', '2025-05-18 04:00:33', '2025-05-18 04:00:33');

-- --------------------------------------------------------

--
-- Table structure for table `user_token`
--

CREATE TABLE `user_token` (
  `user_tokenId` int NOT NULL,
  `userId` int NOT NULL,
  `token` varchar(500) COLLATE utf8mb4_general_ci NOT NULL,
  `expiry_date` datetime NOT NULL,
  `date_created` datetime NOT NULL,
  `last_modified` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `user_token`
--

INSERT INTO `user_token` (`user_tokenId`, `userId`, `token`, `expiry_date`, `date_created`, `last_modified`) VALUES
(1, 8, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySWQiOiI4IiwiRW1haWwiOiJmcHNiaUBnaGIuY20iLCJQYXNzd29yZCI6Ik87a1g9UHV0cjVoPz9gd0lZQjJIIiwiUm9sZSI6IlVzZXIiLCJQYWlkVXNlciI6Ik5vIiwibmJmIjoxNzQ3NTAyMjcwLCJleHAiOjE3NzkwMzgyNzAsImlhdCI6MTc0NzUwMjI3MCwiaXNzIjoiaHR0cHM6Ly80NDRmLTEyOS0wLTYwLTQ5Lm5ncm9rLWZyZWUuYXBwL2FwaSIsImF1ZCI6Imh0dHBzOi8vNDQ0Zi0xMjktMC02MC00OS5uZ3Jvay1mcmVlLmFwcCJ9.coV5zMLDAFPcVh9YxTGpWHTdJUcCRTwUd4Fp_K2RR3Y', '2026-05-17 17:17:50', '2025-05-17 17:17:50', '2025-05-17 17:17:50'),
(2, 10, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySWQiOiIxMCIsIkVtYWlsIjoiamFzb25AbWFpbC5jb20iLCJQYXNzd29yZCI6Ik15UGFzc3dvcmQxIiwiUm9sZSI6IlVzZXIiLCJQYWlkVXNlciI6Ik5vIiwibmJmIjoxNzQ3NTQwODM2LCJleHAiOjE3NzkwNzY4MzYsImlhdCI6MTc0NzU0MDgzNiwiaXNzIjoiaHR0cHM6Ly80NDRmLTEyOS0wLTYwLTQ5Lm5ncm9rLWZyZWUuYXBwL2FwaSIsImF1ZCI6Imh0dHBzOi8vNDQ0Zi0xMjktMC02MC00OS5uZ3Jvay1mcmVlLmFwcCJ9.5CmWPYddMSDttSPIj0NrNB3RskB4ZpZqyM9wNnA201c', '2026-05-18 04:00:36', '2025-05-18 04:00:36', '2025-05-18 04:00:36');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `category`
--
ALTER TABLE `category`
  ADD PRIMARY KEY (`categoryId`),
  ADD UNIQUE KEY `code` (`code`);

--
-- Indexes for table `password`
--
ALTER TABLE `password`
  ADD PRIMARY KEY (`passwordId`),
  ADD KEY `userId` (`userId`);

--
-- Indexes for table `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`productId`),
  ADD UNIQUE KEY `code` (`code`),
  ADD KEY `categoryId` (`categoryId`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`userId`),
  ADD UNIQUE KEY `email` (`email`);

--
-- Indexes for table `user_token`
--
ALTER TABLE `user_token`
  ADD PRIMARY KEY (`user_tokenId`),
  ADD UNIQUE KEY `userId` (`userId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `category`
--
ALTER TABLE `category`
  MODIFY `categoryId` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `password`
--
ALTER TABLE `password`
  MODIFY `passwordId` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `product`
--
ALTER TABLE `product`
  MODIFY `productId` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `userId` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `user_token`
--
ALTER TABLE `user_token`
  MODIFY `user_tokenId` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `password`
--
ALTER TABLE `password`
  ADD CONSTRAINT `password_ibfk_1` FOREIGN KEY (`userId`) REFERENCES `user` (`userId`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `product`
--
ALTER TABLE `product`
  ADD CONSTRAINT `product_ibfk_1` FOREIGN KEY (`categoryId`) REFERENCES `category` (`categoryId`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Constraints for table `user_token`
--
ALTER TABLE `user_token`
  ADD CONSTRAINT `user_token_ibfk_1` FOREIGN KEY (`userId`) REFERENCES `user` (`userId`) ON DELETE CASCADE ON UPDATE CASCADE;

SET FOREIGN_KEY_CHECKS=1;
