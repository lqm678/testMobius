@powershell -ExecutionPolicy RemoteSigned -Command "(New-Object net.webclient).DownloadString(\"%~1\")"