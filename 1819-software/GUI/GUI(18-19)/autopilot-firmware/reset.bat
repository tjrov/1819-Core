MODE %1%: BAUD=500000 PARITY=n DATA=8 STOP=1
printf "\x42\x83\x01\x03\x02" > %1%
avrdude -p m328p -c arduino -b 115200 -P %1 -v -U flash:w:%2:i