import matplotlib.pyplot as plt
import numpy as np


class Point:
    def __init__(self, x, y):
        self.x = x
        self.y = y


def read(filename):
    current_front_level = 1
    elements = {}
    elem_from_front = []

    with open(filename) as f:
        while True:
            line = f.readline()
            front_from_file = int(line.split(' ')[0].replace('F', ''))
            x = float(line.split(' ')[2])
            y = float(line.split(' ')[3])
            if current_front_level == front_from_file:
                elem_from_front.append(Point(x, y))
            else:
                elements[current_front_level] = elem_from_front.copy()
                elem_from_front = [Point(x, y)]
                current_front_level = front_from_file
            if not line.endswith('\n'):
                elements[current_front_level] = elem_from_front.copy()
                break
    return elements


def get_cmap(n, name='hsv'):
    return plt.cm.get_cmap(name, n)


def plot(elements):
    # Daca vrem sa minimizam => comentam
    plt.gca().invert_xaxis()
    plt.gca().invert_yaxis()
    #
    cmap = get_cmap(len(elements) + 1)
    colors = [cmap(i) for i in np.linspace(0, 1, len(elements) + 1)]
    for keys, values in elements.items():
        x = []
        y = []
        for value in values:
            x.append(value.x)
            y.append(value.y)
        if keys == 1:
            colors[keys] = (0.0, 0.0, 0.0, 1.0)
        plt.plot(x, y, color=colors[keys], linestyle='None', marker=".", label="Front: " + str(keys))
    # hide x, y axes
    # plt.xticks([])
    # plt.yticks([])
    plt.legend()
    plt.savefig('result.svg', format='svg', dpi=1200)
    plt.show()


if __name__ == '__main__':
    elements = read("result.txt")
    plot(elements)
