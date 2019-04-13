#Shape Recognition for ROV
#TODO: add command line arguments for file

import cv2
import numpy as np
import time
import sys

inp = str(sys.argv[1])
img = cv2.imread(inp+'.jpg', cv2.IMREAD_GRAYSCALE)
_, threshold = cv2.threshold(img, 240, 255, cv2.THRESH_BINARY)
contours, _ = cv2.findContours(threshold, cv2.RETR_TREE, cv2.CHAIN_APPROX_SIMPLE)

font = cv2.FONT_HERSHEY_COMPLEX

rect = 0
sq = 0
circ = 0
tri = 0

for cnt in contours:
    approx = cv2.approxPolyDP(cnt, 0.01*cv2.arcLength(cnt, True), True)
    cv2.drawContours(img, [approx], 0, (0), 5)
    x = approx.ravel()[0]
    y = approx.ravel()[1]

    if len(approx) == 3:
        cv2.putText(img, "Triangle", (x, y), font, 1, (0))
        tri+=1
    elif len(approx) == 4:
        approx = cv2.approxPolyDP(cnt,0.01*cv2.arcLength(cnt,True),True)
        area = cv2.contourArea(cnt)

        (x, y, w, h) = cv2.boundingRect(approx)
        if  abs(w-h)<=10:
            cv2.putText(img, "Square", (x, y), font, 0.7, 0, 2)
            sq+=1
        else:
            cv2.putText(img, "Rectangle", (x, y), font, 0.7, 0, 2)
            rect+=1
    elif 6 < len(approx) < 15:
        cv2.putText(img, "Rectangle", (x, y), font, 1, (0))
        rect+=1
    else:
        cv2.putText(img, "Circle", (x, y), font, 1, (0))
        circ+=1

img2 = np.zeros((400, 400, 3), dtype = "uint8")
cv2.line(img2, (20, 60), (100, 60), (0, 0, 255), 10)
cv2.putText(img2, str(rect-1), (300, 60), font, 0.8, (0, 0, 255), 2, cv2.LINE_AA)

cv2.rectangle(img2, (20, 90), (100, 170), (0, 0, 255), -1) 
cv2.putText(img2, str(sq), (300, 120), font, 0.8, (0, 0, 255), 2, cv2.LINE_AA)

cv2.circle(img2,(60, 240), 40, (0, 0, 255), -1)
cv2.putText(img2, str(circ), (300, 240), font, 0.8, (0, 0, 255), 2, cv2.LINE_AA)

triangle_cnt = np.array( [(60, 310), (20, 390), (100, 390)] )
cv2.drawContours(img2, [triangle_cnt], 0, (0,0,255), -1)
cv2.putText(img2, str(tri), (300, 350), font, 0.8, (0, 0, 255), 2, cv2.LINE_AA)

cv2.imwrite(inp+'P.jpg', img2)
cv2.imwrite('shapesP3.jpg', img)
cv2.waitKey(0)
cv2.destroyAllWindows()
