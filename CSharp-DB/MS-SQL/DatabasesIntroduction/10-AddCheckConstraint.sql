ALTER TABLE Users
ADD CONSTRAINT CHK_PasswordMinLen CHECK(LEN([Password]) >= 5);