from numpy import array
from LinearSystem import TSystemLinearEquation


class TwoSystemLinearEquation(TSystemLinearEquation):
    def __init__(self, coefficients):
        super().__init__(coefficients)
        self.__coefficients = array(coefficients)

    def __str__(self):
        lin_system = ''
        for row in self.__coefficients:
            lin_system += f'{row[0]}x + {row[1]}y = {row[2]}\n'

        return lin_system
