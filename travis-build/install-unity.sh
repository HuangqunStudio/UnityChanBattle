#! /bin/sh

# Refer to https://unity3d.com/get-unity/download/archive for unityhub://$VERSION/$HASH link
BASE_URL=https://download.unity3d.com/download_unity
VERSION=2019.1.11
HASH=9b001d489a54

download() {
#  package=$1
  url="$BASE_URL/$HASH/$package"

  echo "Downloading from $url"
  curl -o `basename "$package"` "$url"
}

install() {
  package=$1
  download "$package"

  echo "Installing "`basename "$package"`
  sudo installer -dumplog -package `basename "$package"` -target /
}

# See $BASE_URL/$HASH/unity-$VERSION-osx.ini for a complete list of packages
install "MacEditorInstaller/Unity-$VERSION.pkg"
install "MacEditorTargetInstaller/UnitySetup-Mac-IL2CPP-Support-for-Editor-$VERSION.pkg"
install "MacEditorTargetInstaller/UnitySetup-iOS-Support-for-Editor-$VERSION.pkg"
