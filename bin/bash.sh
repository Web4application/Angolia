dotnet add package Algolia.Search --version 7.0.0
dotnet new console -n seekit
cd seekit
dotnet add package seekit.Search --version 7.0.0
# .dll
dotnet add package.Search --version 7.0.0

curl -O https://download.swift.org/swiftly/darwin/swiftly.pkg && \
installer -pkg swiftly.pkg -target CurrentUserHomeDirectory && \
~/.swiftly/bin/swiftly init --quiet-shell-followup && \
. "${SWIFTLY_HOME_DIR:-$HOME/.swiftly}/env.sh" && \
hash -r
