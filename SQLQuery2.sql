-- attach the existing MDF as logical database "housing100"
CREATE DATABASE housing100
ON  ( FILENAME = N'C:\Users\W10\Desktop\CRMProject\CRMProject\DB\housing100.mdf' )
FOR ATTACH;
GO

CREATE DATABASE housing100
ON
  ( FILENAME = N'C:\...\housing100.mdf' ),
  ( FILENAME = N'C:\...\housing100_log.ldf' )
FOR ATTACH;
