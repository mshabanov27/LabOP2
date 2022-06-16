from abc import ABC
import numpy.linalg
from numpy import array


class TSystemLinearEquation(ABC):
    def __init__(self, coefficients):
        self.__coefficients = array(coefficients)

    def kramer_method(self):
        A, B = self.__coefficients[:, :-1], self.__coefficients[:, -1]
        roots = []
        determinant = self.count_determinant(A)
        if determinant != 0:
            index = 0
            while index < len(A):
                replaced = self.make_replaced_matrix(A, index, B)
                roots.append(self.count_determinant(replaced))
                roots[index] /= determinant
                index += 1

            return roots

    def matrix_method(self):
        A, B = self.__coefficients[:, :-1], self.__coefficients[:, -1]
        determinant = numpy.linalg.det(A)
        if determinant != 0:
            inverted_matrix = numpy.linalg.inv(A)
            roots = numpy.matmul(inverted_matrix, B)
            return roots

    def count_determinant(self, matrix):
        det = 0
        if len(matrix) == 2:
            det += matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0]
        else:
            det += matrix[0, 0] * matrix[1, 1] * matrix[2, 2]
            det += matrix[0, 1] * matrix[1, 2] * matrix[2, 0]
            det += matrix[0, 2] * matrix[1, 0] * matrix[2, 1]
            det -= matrix[0, 2] * matrix[1, 1] * matrix[2, 0]
            det -= matrix[0, 1] * matrix[1, 0] * matrix[2, 2]
            det -= matrix[0, 0] * matrix[1, 2] * matrix[2, 1]
        return det

    def make_replaced_matrix(self, main_matrix, index, replacer):
        temp = main_matrix
        i = 0
        while i < len(temp):
            main_matrix[i, index] = replacer[i]
            i += 1
        return temp
