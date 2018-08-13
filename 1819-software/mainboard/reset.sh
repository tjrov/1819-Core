#!/bin/bash

stty -F /dev/ttyAMA0 115200
echo -e "\x42\x83\x01\x03\x02" > /dev/ttyAMA0
echo "Reset complete"
