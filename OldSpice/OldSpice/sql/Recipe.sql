-- Active: 1666715462927@@SG-fossil-throne-24-6835-mysql-master.servers.mongodirector.com@3306@FossilThrone

CREATE TABLE
    IF NOT EXISTS recipe(
        id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        title VARCHAR(255) NOT NULL,
        instructions LONGTEXT,
        img VARCHAR(1000) NOT NULL,
        category VARCHAR(255) NOT NULL,
        creatorId VARCHAR(255) NOT NULL,
        FOREIGN KEY (creatorId) REFERENCES accounts(id)
    ) default charset utf8 COMMENT '';

SELECT
    rec.*,
    a.id AS accountId,
    a.*
From recipe rec
    JOIN accounts a ON a.id = rec.creatorId;