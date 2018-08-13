echo "Reset script start"
Mode COM7: Baud=115200 Parity=N Data=8 Stop=1
printf "%b" '\x42\x83\x01\x03\x02' > COM7
echo "Reset command sent"