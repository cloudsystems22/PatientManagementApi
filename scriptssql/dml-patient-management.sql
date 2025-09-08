-- Script DDL para CRUD
-- Scripts para Atendimento
SELECT Id, SequenceNumber, PatientId, ArrivalTime, Status
FROM PatientManagementDb.dbo.Care;

SELECT Id, SequenceNumber, PatientId, ArrivalTime, Status
FROM PatientManagementDb.dbo.Care
WHERE Id=N'c11c01df';

INSERT INTO PatientManagementDb.dbo.Care
(Id, SequenceNumber, PatientId, ArrivalTime, Status)
VALUES('', '', '', '', 0);

UPDATE PatientManagementDb.dbo.Care
SET SequenceNumber='', PatientId='', ArrivalTime='', Status=0
WHERE Id='';

DELETE FROM PatientManagementDb.dbo.Care
WHERE Id='';

-- Scripts para Especialidades
SELECT Id, Name
FROM PatientManagementDb.dbo.Speciality;

SELECT Id, Name
FROM PatientManagementDb.dbo.Speciality
WHERE Id=N'033be0';

INSERT INTO PatientManagementDb.dbo.Speciality
(Id, Name)
VALUES('', '');

UPDATE PatientManagementDb.dbo.Speciality
SET Name=''
WHERE Id='';

DELETE FROM PatientManagementDb.dbo.Speciality
WHERE Id='';

-- Script para Triagens
SELECT Id, CareId, Symptoms, BloodPressure, Weight, Height, SpecialityId
FROM PatientManagementDb.dbo.Triage;

SELECT Id, CareId, Symptoms, BloodPressure, Weight, Height, SpecialityId
FROM PatientManagementDb.dbo.Triage
WHERE Id=N'077be9';

INSERT INTO PatientManagementDb.dbo.Triage
(Id, CareId, Symptoms, BloodPressure, Weight, Height, SpecialityId)
VALUES('', '', '', '', 0, 0, '');

UPDATE PatientManagementDb.dbo.Triage
SET CareId='', Symptoms='', BloodPressure='', Weight=0, Height=0, SpecialityId=''
WHERE Id='';

DELETE FROM PatientManagementDb.dbo.Triage
WHERE Id='';


