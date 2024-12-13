import time
from enum import Enum

MAX_SIZE = 30

#region Szinek a konzolon
class Color(Enum):
    RESET = "\033[0m"
    BLACK = "\033[40m"
    RED = "\033[41m"
    GREEN = "\033[42m"
    YELLOW = "\033[43m"
    BLUE = "\033[44m"
    MAGENTA = "\033[45m"
    CYAN = "\033[46m"
    WHITE = "\033[47m"

def color_print(color):
    print(f"{color.value} ", end=Color.RESET.value)

#endregion

#region Kepek fajlbol
class Image:
    def __init__(self, width, height, matrix):
        self.width = width
        self.height = height
        self.matrix = matrix

def image_print(img):
    for item in img.matrix:
        for color in item:
            color_print(color)
        print()

def read_image(file_path):
    with open(file_path, 'r') as f:
        width = int(f.readline())
        height = int(f.readline())
        
        if width > MAX_SIZE or height > MAX_SIZE:
            print("Tul nagy a kep!")
        
        matrix = []
        for _ in range(height):
            row = list(map(int, f.readline().split()))
            matrix.append([
                Color.BLACK if x == 0 else
                Color.RED if x == 1 else
                Color.GREEN if x == 2 else
                Color.YELLOW if x == 3 else
                Color.BLUE if x == 4 else
                Color.MAGENTA if x == 5 else
                Color.CYAN if x == 6 else
                Color.WHITE
                for x in row
            ])
    return Image(width, height, matrix)

#endregion

#region Gif fajlbol
class Gif:
    def __init__(self, frames):
        self.frames = frames

def print_gif(gif):
    for frame in gif.frames:
        print("\033[2J\033[H", end="")
        image_print(frame)
        time.sleep(0.2)

def load_gif(file):
    frames=[]
    for i in range(10):
        file_name = f"{file}.bg{i}"
        frames.append(read_image(file_name))
    return Gif(frames)

#endregion

#region main
color_print(Color.YELLOW)
print()

image = read_image("input.txt")
image_print(image)

base = input("Add meg a fajl nevet (pl. 'input'): ")

gif = load_gif(base)
print_gif(gif)

#endregion
