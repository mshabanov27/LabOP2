from numpy import array
from LinearSystem import TSystemLinearEquation


class ThreeSystemLinearEquation(TSystemLinearEquation):
    def __init__(self, coefficients):
        super().__init__(coefficients)
        self.__coefficients = array(coefficients)

    def __str__(self):
        lin_system = ''
        for row in self.__coefficients:
            lin_system += f'{row[0]}x + {row[1]}y '
            lin_system += f'{row[2]}z = {row[3]}\n'

        return lin_system
