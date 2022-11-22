((Get-Content -path .\bin\jodo\index.html -Raw) -replace 'html/','api/') | Set-Content -Path .\bin\jodo\index.html
((Get-Content -path .\bin\jodo\PageNotFound.html -Raw) -replace 'html/','api/') | Set-Content -Path .\bin\jodo\PageNotFound.html
((Get-Content -path .\bin\jodo\search.html -Raw) -replace 'html/','api/') | Set-Content -Path .\bin\jodo\search.html
((Get-Content -path .\bin\jodo\fti\FTI_Files.json -Raw) -replace 'html/','api/') | Set-Content -Path .\bin\jodo\fti\FTI_Files.json
Rename-Item -Path .\bin\jodo\html -NewName "api"