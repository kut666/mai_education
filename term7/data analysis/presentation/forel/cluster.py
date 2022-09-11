import matplotlib
import forel
import reader
import sys
import matplotlib.pyplot as plt

"""
Usage:
- execute "python writer.py <datafile> <radius>"
(datafile contains data points; radius specifies the cluster size)

The program will cluster input points using FOREL algorithm and
display them together with found centroids.
"""


def display(data, centroids, width=50, height=50):
    board = plt.figure()
    ax = board.add_subplot(111)
    ax.set_xlim([0, width])
    ax.set_ylim([0, height])
    # board.canvas.mpl_connect('button_press_event', onclick)
    for point in data:
        plt.plot(point[0], point[1], 'bo')
    for point in centroids:
        plt.plot(point[0], point[1], 'ro')
        circle = plt.Circle((point[0], point[1]), 10, color = 'r', fill=False)
        ax.add_patch(circle)
    board.canvas.draw()
    plt.show()


def main(data_file, radius):
    if data_file is None:
        raise ValueError('Specify file to store data points!')
    if radius is None:
        raise ValueError('Specify cluster radius!')
    data = reader.get_points_from_file(data_file)
    centroids = forel.cluster(data, float(radius))
    display(data, centroids)


if __name__ == "__main__":
    if len(sys.argv) != 3:
        print('Usage: "writer.py <datafile> <radius>"')
    else:
        main(sys.argv[1], sys.argv[2])
