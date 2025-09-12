def task1(list):
    for idx in range(len(list)):
        i = list[idx]
        if i < 0 and i % 2 == 0:
            list[idx] = i*2
        else:
            list[idx] = i/2

    d = {}
    for i in list:
        if i in d:
            d[i] += 1
        else:
            d[i] = 1
    return d