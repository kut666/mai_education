import numpy as np


def get_points_from_file(path, delimiter=" "):
    points = []
    with open(path, 'r') as f:
        for line in f:
            coordinates = line.split(delimiter)
            if len(coordinates) == 2:
                try:
                    x = float(coordinates[0])
                    y = float(coordinates[1])
                    points.append([x, y])
                except ValueError:
                    print("Data file contains invalid line:", line)
    return np.array(points)
