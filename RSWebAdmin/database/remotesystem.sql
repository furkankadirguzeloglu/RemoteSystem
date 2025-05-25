SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+03:00";

CREATE TABLE `accounts` (
  `ID` int(10) UNSIGNED NOT NULL,
  `Username` text NOT NULL,
  `Password` text NOT NULL,
  `Email` text NOT NULL,
  `Devices` text NOT NULL,
  `Token` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;


CREATE TABLE `devices` (
  `ID` int(10) UNSIGNED NOT NULL,
  `UserID` int(10) UNSIGNED NOT NULL,
  `Hwid` text NOT NULL,
  `LastSeen` text NOT NULL,
  `HardwareInfo` longtext NOT NULL,
  `ClientInfo` longtext NOT NULL,
  `Task` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE `screens` (
  `UserID` int(10) UNSIGNED NOT NULL,
  `DeviceID` int(10) UNSIGNED NOT NULL,
  `Data` longblob NOT NULL,
  `LastDataTime` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE `logs` (
  `UserID` int(10) UNSIGNED NOT NULL,
  `DeviceID` int(10) UNSIGNED NOT NULL,
  `Log` longtext NOT NULL,
  `Time` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

ALTER TABLE `accounts`
  ADD PRIMARY KEY (`ID`);

ALTER TABLE `devices`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `fk_Devices_accounts` (`UserID`);

ALTER TABLE `logs`
  ADD KEY `fk_Logs_Accounts` (`UserID`),
  ADD KEY `fk_Logs_Devices` (`DeviceID`);

ALTER TABLE `screens`
  ADD KEY `fk_Screens_Accounts` (`UserID`),
  ADD KEY `fk_Screens_Devices` (`DeviceID`);

ALTER TABLE `accounts`
  MODIFY `ID` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

ALTER TABLE `devices`
  MODIFY `ID` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

ALTER TABLE `devices`
  ADD CONSTRAINT `fk_Devices_accounts` FOREIGN KEY (`UserID`) REFERENCES `accounts` (`ID`) ON DELETE CASCADE;

ALTER TABLE `logs`
  ADD CONSTRAINT `fk_Logs_Accounts` FOREIGN KEY (`UserID`) REFERENCES `accounts` (`ID`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_Logs_Devices` FOREIGN KEY (`DeviceID`) REFERENCES `devices` (`ID`) ON DELETE CASCADE;

ALTER TABLE `screens`
  ADD CONSTRAINT `fk_Screens_Accounts` FOREIGN KEY (`UserID`) REFERENCES `accounts` (`ID`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_Screens_Devices` FOREIGN KEY (`DeviceID`) REFERENCES `devices` (`ID`) ON DELETE CASCADE;
COMMIT;