#! /bin/sh

UNITY_PROJECT_NAME="UnityChanBattle"

if [ -z "${CI}" ]; then
    UNITY_PATH="/Applications/Unity/Hub/Editor/2019.1.11/Unity.app/Contents/MacOS/Unity"
else
    UNITY_PATH="/Applications/Unity/Unity.app/Contents/MacOS/Unity"
fi
UNITY_BUILD_DIR=$(pwd)/builds
OSX_LOG_FILE=$UNITY_BUILD_DIR/OSX.log

echo "Attempting to build $UNITY_PROJECT_NAME for OSX"
${UNITY_PATH} \
  -username ${UNITY_USER} \
  -password ${UNITY_PWD} \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile "$OSX_LOG_FILE" \
  -projectPath "$(pwd)" \
  -buildOSXUniversalPlayer "$UNITY_BUILD_DIR/OSX/$UNITY_PROJECT_NAME.app" \
  -quit
rc1=$?
echo 'OSX build logs:'
cat $OSX_LOG_FILE

STATUS_CODE=$(($rc1))
echo "Finishing with code $STATUS_CODE"
exit $STATUS_CODE
