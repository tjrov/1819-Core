echo "upload.bat Start"

echo "Sending reset command to autopilot board"
echo "(42 83 01 03 02)"
MODE %1%: BAUD=500000 PARITY=n DATA=8 STOP=1
printf "\x42\x83\x01\x03\x02" > %1%

echo "upload.bat End"