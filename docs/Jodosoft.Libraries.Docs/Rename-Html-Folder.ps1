((Get-Content -path .\bin\docs\index.html -Raw) -replace 'html/','api/') | Set-Content -Path .\bin\docs\index.html
((Get-Content -path .\bin\docs\PageNotFound.html -Raw) -replace 'html/','api/') | Set-Content -Path .\bin\docs\PageNotFound.html
((Get-Content -path .\bin\docs\search.html -Raw) -replace 'html/','api/') | Set-Content -Path .\bin\docs\search.html
((Get-Content -path .\bin\docs\fti\FTI_Files.json -Raw) -replace 'html/','api/') | Set-Content -Path .\bin\docs\fti\FTI_Files.json
Rename-Item -Path .\bin\docs\html -NewName "api"