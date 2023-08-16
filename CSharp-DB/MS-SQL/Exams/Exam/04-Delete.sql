DELETE [CreatorsBoardgames]
 WHERE [BoardgameId] IN (
							SELECT [Id]
							  FROM [Boardgames]
							 WHERE [PublisherId] IN (
															SELECT [Id]
															  FROM [Publishers]
															 WHERE [AddressId] IN (
																						SELECT [Id]
																						  FROM [Addresses]
																						 WHERE SUBSTRING([Town], 1, 1) = 'L'
																				   )
													)
						);

DELETE [Boardgames]
 WHERE [PublisherId] IN (
							SELECT [Id]
							  FROM [Publishers]
							 WHERE [AddressId] IN (
														SELECT [Id]
														  FROM [Addresses]
														 WHERE SUBSTRING([Town], 1, 1) = 'L'
												  )
						);

DELETE [Publishers]
 WHERE [AddressId] IN (
							SELECT [Id]
							  FROM [Addresses]
							 WHERE SUBSTRING([Town], 1, 1) = 'L'
					  );

DELETE [Addresses]
 WHERE SUBSTRING([Town], 1, 1) = 'L';