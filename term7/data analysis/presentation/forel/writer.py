import matplotlib.pyplot as plt
import os
import sys

"""
Usage:
- execute "python writer.py <datafile>" (datafile is the path where input points are stored)
- select necessary points on the board to add them to the data set
- close the board.

Selected points will be stored in <datafile> with a point in each line.
"""

points = []
board = plt.figure()


def onclick(event):
    global points
    global board
    plt.plot(event.xdata, event.ydata, 'ro')
    points.append((float(event.xdata), float(event.ydata)))
    board.canvas.draw()


def get_points_from_canvas(width, height):
    global points
    global board
    points = []
    ax = board.add_subplot(111)
    ax.set_xlim([0, width])
    ax.set_ylim([0, height])
    board.canvas.mpl_connect('button_press_event', onclick)
    plt.show()
    return points


def main(data_path):
    if data_path is None:
        raise ValueError('Specify file to store data points!')
    input_points = get_points_from_canvas(50, 50)
    with open(data_path, 'w', encoding='utf8') as dest:
        for p in input_points:
            dest.write('{0} {1}\n'.format(p[0], p[1]))


if __name__ == "__main__":
    if len(sys.argv) < 2:
        print('Usage: "writer.py <datafile>"')
    main(sys.argv[1])
