CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR (255) NOT NULL primary key COMMENT 'Primary Key',
  create_time DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Create Time',
  update_time DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Update Time',
  name VARCHAR (255) COMMENT 'Account Name',
  email VARCHAR (255) COMMENT 'Account Email',
  picture VARCHAR (255) COMMENT 'Account Picture'
) default charset utf8 comment '';
CREATE TABLE IF NOT EXISTS vaults(
  id int NOT NULL primary key AUTO_INCREMENT COMMENT 'Primary Key',
  creatorId VARCHAR (255) COMMENT 'FK: Vault Creator Id',
  create_time DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Create Time',
  update_time DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Update Time',
  name VARCHAR (255) COMMENT 'Vault Name',
  description VARCHAR (255) COMMENT 'Vault Description',
  isPrivate BOOL COMMENT 'Vault Privacy',
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 comment '';
CREATE TABLE IF NOT EXISTS keeps(
  id int NOT NULL primary key AUTO_INCREMENT COMMENT 'Primary Key',
  creatorId VARCHAR (255) COMMENT 'FK: Keep Creator Id',
  create_time DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Create Time',
  update_time DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Update Time',
  name VARCHAR (255) COMMENT 'Keep Name',
  description VARCHAR (255) COMMENT 'Keep Description',
  img VARCHAR (255) COMMENT 'Keep Image',
  views INT COMMENT 'Keep Views',
  shares INT COMMENT 'Keep Shares',
  keeps INT COMMENT 'Keep Keeps',
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 comment '';
-- ************************************************************
-- *****Do not create a profiles table, only use accounts.*****
-- ************************************************************
-- CREATE TABLE IF NOT EXISTS profiles(
--   id int NOT NULL PRIMARY KEY AUTO_INCREMENT COMMENT 'Primary Key',
--   create_time DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Create Time',
--   update_time DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Update Time',
--   name VARCHAR (255) COMMENT 'Profile Name',
--   email VARCHAR (255) COMMENT 'Profile Email',
--   picture VARCHAR (255) COMMENT 'Account Picture'
-- ) default charset utf8 comment '';
-- ************************************************************
CREATE TABLE IF NOT EXISTS vaultkeeps(
  id int NOT NULL primary key AUTO_INCREMENT COMMENT 'Primary Key',
  create_time DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Create Time',
  update_time DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Update Time',
  creatorId VARCHAR (255) COMMENT 'FK: Account Id',
  vaultId INT COMMENT 'FK: Vault Id',
  keepId INT COMMENT 'FK: Keep Id',
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE,
  FOREIGN KEY (vaultId) REFERENCES vaults(id) ON DELETE CASCADE,
  FOREIGN KEY (keepId) REFERENCES keeps(id) ON DELETE CASCADE
) default charset utf8 comment '';
SELECT
  k.*,
  p.*
FROM
  keeps k
  JOIN profiles p ON p.id = k.creatorId
WHERE
  k.creatorId = "88440d6ea76640508b03e215795939b0";
DROP TABLE profiles