-- Kategoriler
INSERT INTO Categories(Id, Name, Description, CreatedDate)
VALUES
    ('9f378682-bee5-4c62-a8c7-36eb1d14c305', 'Yazılım', 'Yazılım eğitimleri içeriği', GETDATE()),
    ('2a038ea0-950f-4d3c-a7f7-b6b6abc0bcc1', 'Finans ve Muhasebe', 'Finans ve Muhasebe eğitimleri içeriği', GETDATE()),
    ('ec5834f6-a9a4-4889-ad1d-7e9fd11f534e', 'Sağlık ve Fitness', 'Sağlık ve fitness ile ilgili eğitimlerin bulunduğu kategori', GETDATE()),
    ('c9cd4337-c5c0-4e97-b568-d1f357d57c6f', 'Sanat ve Tasarım', 'Sanat ve tasarım konularında eğitimlerin bulunduğu kategori', GETDATE()),
    ('affb0ced-b247-41dd-acac-e1e6f9424129', 'Yabancı Dil', 'Yabancı dil öğrenimiyle ilgili eğitimlerin bulunduğu kategori', GETDATE()),
    ('a7ad193b-4910-4df2-a370-7eee9710514e', 'Kişisel Gelişim', 'Kişisel gelişim ve liderlik konularında eğitimlerin bulunduğu kategori', GETDATE()),
    ('94561889-5369-4dcd-82e4-d0d7f83cdf4f', 'Temel Lise Dersleri', 'Temel Lise eğitimlerin bulunduğu kategori', GETDATE());


-- Kurslar
INSERT INTO Courses(Id,CategoryId,SortNumber,Status, Name, Description, CreatedDate)
VALUES
    ('4155b25d-017e-4f8f-a6fe-6dc58d674fd9','94561889-5369-4dcd-82e4-d0d7f83cdf4f',5,1, 'Matematik', 'Matematik dersi içeriği', GETDATE()),
    ('b2c6d44a-c072-49b7-9ccb-558c20c749c5','94561889-5369-4dcd-82e4-d0d7f83cdf4f',5,1, 'Fizik', 'Fizik dersi içeriği', GETDATE()),
	('7fe2fbf5-987c-4f12-b10b-df76f3d8b320','9f378682-bee5-4c62-a8c7-36eb1d14c305',5,1, 'Python Programlama', 'Python programlama dilini öğrenmek için kapsamlı bir kurs', GETDATE()),
    ('3f3e3ecf-bd9e-476e-aaf7-c3a5a49b82c4','9f378682-bee5-4c62-a8c7-36eb1d14c305',5,1, 'Veri Bilimi Temelleri', 'Veri bilimi dünyasına giriş yapmak için temel bilgilerin öğretildiği bir kurs', GETDATE()),
    ('94f0a7e7-4325-43d9-bc07-4ccee2a4e103','94561889-5369-4dcd-82e4-d0d7f83cdf4f',5,1, 'Kimya', 'Kimya dersi içeriği', GETDATE());

-- İçerikler
INSERT INTO CourseContents(Id,SortNumber, Summary, CourseId, CreatedDate)
VALUES
    ('bb7497d7-1396-4161-9cf5-f4acd18f8638',5, 'Matematik dersi içeriği 1', '4155b25d-017e-4f8f-a6fe-6dc58d674fd9', GETDATE()),
    ('d51a5581-aa7f-4e59-b689-e9154976ccc5',5, 'Matematik dersi içeriği 2', '4155b25d-017e-4f8f-a6fe-6dc58d674fd9', GETDATE()),
    ('fa911e6b-7761-436b-bcb4-5cc2305cdf99', 5,'Matematik dersi içeriği 3', '4155b25d-017e-4f8f-a6fe-6dc58d674fd9', GETDATE()),

    ('ff9d1c8c-4b4d-4595-a7d1-216579be2010',5, 'Fizik dersi içeriği 1', 'b2c6d44a-c072-49b7-9ccb-558c20c749c5', GETDATE()),
    ('0eff8ae8-6ff0-4e66-8f7f-0935576b0210',5, 'Fizik dersi içeriği 2', 'b2c6d44a-c072-49b7-9ccb-558c20c749c5', GETDATE()),
    ('0a555139-9198-405f-9438-1724587e41a5',5, 'Fizik dersi içeriği 3', 'b2c6d44a-c072-49b7-9ccb-558c20c749c5', GETDATE()),

    ('b2922346-5e77-492b-81b2-2051bc291185',5, 'Kimya dersi içeriği 1', '94f0a7e7-4325-43d9-bc07-4ccee2a4e103', GETDATE()),
    ('aa7844b9-7496-46d3-ba19-269340daab32',5, 'Kimya dersi içeriği 2', '94f0a7e7-4325-43d9-bc07-4ccee2a4e103', GETDATE()),
    ('4e554e93-dd03-4888-85ac-1c4afa51799f',5, 'Kimya dersi içeriği 3', '94f0a7e7-4325-43d9-bc07-4ccee2a4e103', GETDATE()),

	('94a4f3f8-2ad5-4e64-a512-92a9b4a50dc5',5, 'Python programlama diline giriş', '7fe2fbf5-987c-4f12-b10b-df76f3d8b320', GETDATE()),
    ('b2781662-d872-4a1f-a17d-dc83f74087df', 5,'Pythonda ileri seviye konular', '7fe2fbf5-987c-4f12-b10b-df76f3d8b320', GETDATE()),
    ('d4c081d7-0522-4eeb-9a57-6f3dbab3daa1',5, 'Veri bilimi nedir?', '3f3e3ecf-bd9e-476e-aaf7-c3a5a49b82c4', GETDATE()),
    ('f4a0d8e4-9d8e-4cbf-998f-7de57fc62e25',5, 'Veri toplama ve temizleme yöntemleri', '3f3e3ecf-bd9e-476e-aaf7-c3a5a49b82c4', GETDATE());

-- CourseDocument tablosuna veri ekleme
INSERT INTO CourseDocuments(Id, FileName, FileExtension, Type, Duration, FileSize, CourseContentId, CreatedDate)
VALUES
    ('05b51c22-4000-4e2f-8308-27496b3d7823', 'example_document1', '.pdf', '1', 60, 1024, 'bb7497d7-1396-4161-9cf5-f4acd18f8638', GETDATE()),
    ('866d6a33-6e2e-4c16-b3a9-9d2c5d8582ab', 'example_document2', '.pdf', '1', 45, 768, 'd51a5581-aa7f-4e59-b689-e9154976ccc5', GETDATE()),
    ('d18d50d3-4204-49ae-b22e-cd58cafecb7d', 'example_document3', '.pdf', '1', 30, 512, 'fa911e6b-7761-436b-bcb4-5cc2305cdf99', GETDATE()),

    ('73d23340-d6aa-4046-9429-44bad9f60392', 'example_document4', '.pdf', '1', 75, 2048, 'ff9d1c8c-4b4d-4595-a7d1-216579be2010', GETDATE()),
    ('bf77f8d2-7ace-42b6-9e46-32fc667ee2bd', 'example_document5', '.pdf', '1', 55, 1536, '0eff8ae8-6ff0-4e66-8f7f-0935576b0210', GETDATE()),
    ('e9d2d95b-e4e4-4f7a-974f-3db3daa72cc5', 'example_document6', '.pdf', '1', 40, 1024, '0a555139-9198-405f-9438-1724587e41a5', GETDATE()),

    ('8a69cab0-174c-41ac-912f-8429c422b8a8', 'example_document7', '.pdf', '1', 90, 4096, 'b2922346-5e77-492b-81b2-2051bc291185', GETDATE()),
    ('1e3a05aa-a880-4b27-8eaa-ef8e04ebd3c3', 'example_document8', '.pdf', '1', 60, 3072, 'aa7844b9-7496-46d3-ba19-269340daab32', GETDATE()),
    ('6f467df5-8b28-4751-9751-ff5bd01fa1a4', 'example_document9', '.pdf', '1', 50, 2048, '4e554e93-dd03-4888-85ac-1c4afa51799f', GETDATE()),
	 ('b5a1c6b9-09c4-4e94-8ec0-08c72efb5fc0', 'python_basics', '.pdf', '1', 45, 512, '94a4f3f8-2ad5-4e64-a512-92a9b4a50dc5', GETDATE()),
    ('d1b96bc9-4c35-4b7e-b9e1-37d36e80c2e8', 'python_advanced', '.pdf', '1', 60, 768, 'b2781662-d872-4a1f-a17d-dc83f74087df', GETDATE()),
    ('2bf2f032-7927-46f4-b9f4-df66f82a90d7', 'data_science_intro', '.pdf', '1', 30, 256, 'd4c081d7-0522-4eeb-9a57-6f3dbab3daa1', GETDATE()),
    ('8e2ac174-c125-4b20-9a78-539b89673fd4', 'data_collection_methods', '.pdf', '1', 40, 384, 'f4a0d8e4-9d8e-4cbf-998f-7de57fc62e25', GETDATE());





