# Access Database Engine 32-bit y�kleyici dosyas�n�n yolu
$installerPath = "AccessDatabaseEngine.exe"

# Y�kleyiciyi sessiz modda �al��t�rma
Start-Process -FilePath $installerPath -ArgumentList "/quiet" -Wait
