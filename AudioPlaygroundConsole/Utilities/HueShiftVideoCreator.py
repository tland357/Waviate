import numpy as np
from matplotlib import pyplot as plt
import cv2
from moviepy.editor import ImageSequenceClip

def make_edit(im, hue):
    # Make signed and larger to accommodate wrap-around
    # Add constant amount of hue to each pixel, wrapping around at 255
    im = im.astype(np.int32)
    im[:,:,0] = (im[:,:,0] + hue) % 255
    return np.clip(im,0,255).astype(np.uint8)

def CreateHueVideo(pictureURL, videoURL):
    imageBase = plt.imread(pictureURL)
    imageBase = imageBase * 255
    imageBase = imageBase.astype(np.uint8)
    hsvBase = cv2.cvtColor(imageBase, cv2.COLOR_BGR2HSV_FULL)
    print(hsvBase.dtype)
    fps = 24
    size = imageBase.shape[0],imageBase.shape[1]
    
    numHueShifts = 255
    hueShiftAmount = 1
    frames = []
    frames.append(imageBase)
    imageNew = hsvBase
    for i in range(int(numHueShifts)):
        print("Frame # = " + str(i))
        imageNew = make_edit(imageNew, hueShiftAmount)
        addNew = cv2.cvtColor(imageNew, cv2.COLOR_HSV2RGB_FULL)
        frames.append(addNew)
    clip = ImageSequenceClip(frames, fps = 24)
    clip.write_gif(videoURL, fps=24)
        
    
CreateHueVideo("../Pictures/WaviateLogo.png", "../Pictures/WaviateLogo.gif")